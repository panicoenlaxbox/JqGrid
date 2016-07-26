using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JqGrid.Infrastructure
{
    public class JqGridResult : ActionResult
    {
        private readonly JqGridData _data;

        public JqGridResult(JqGridData data)
        {
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            var writer = new JsonTextWriter(response.Output);
            var serializer = JsonSerializer.Create(new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            serializer.Serialize(writer, _data);
            writer.Flush();
        }
    }
}