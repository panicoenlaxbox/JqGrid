using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JqGrid.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm</remarks>
    public class JqGridJsonConverter : JsonConverter
    {
        private static void WriteProperty(string name, object value, JsonWriter writer)
        {
            writer.WritePropertyName(name);
            writer.WriteValue(value);
        }

        private static bool HasId(JqGridData data)
        {
            if (!data.Rows.Any())
            {
                return false;
            }
            var jObject = JObject.FromObject(data.Rows.First());
            return jObject.Properties().Any(p => p.Name.ToLower() == "id");
        }

        private static JToken GetId(JObject jObject)
        {
            return jObject.GetValue("Id", StringComparison.InvariantCultureIgnoreCase);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jqGridData = (JqGridData) value;
            writer.WriteStartObject();
            WriteProperty(jqGridData.Configuration.Total, jqGridData.Total, writer);
            WriteProperty(jqGridData.Configuration.Page, jqGridData.Page, writer);
            WriteProperty(jqGridData.Configuration.Records, jqGridData.Records, writer);
            writer.WritePropertyName(jqGridData.Configuration.Root);
            var hasId = HasId(jqGridData);
            JArray jArray = JArray.FromObject(jqGridData.Rows);
            JArray newjArray = new JArray();
            foreach (JToken jToken in jArray)
            {
                JObject jObject = (JObject) jToken;
                JObject newjObject = new JObject();
                if (hasId && jqGridData.Configuration.IncludeId)
                {
                    JToken id = GetId(jObject);
                    newjObject.Add(jqGridData.Configuration.Id, id);
                    if (jqGridData.Configuration.ExcludeIdFromCell)
                    {
                        jObject.Remove("Id");
                    }
                }
                IJEnumerable<JToken> values = jObject.Values();
                newjObject.Add(new JProperty(jqGridData.Configuration.Cell, new JArray(values)));
                newjArray.Add(newjObject);
            }
            newjArray.WriteTo(writer);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}