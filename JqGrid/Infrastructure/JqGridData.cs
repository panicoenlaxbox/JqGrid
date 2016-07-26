using System.Collections.Generic;
using Newtonsoft.Json;

namespace JqGrid.Infrastructure
{
    [JsonConverter(typeof(JqGridJsonConverter))]
    public class JqGridData
    {
        private readonly JqGridDataConfiguration _configuration;

        public JqGridData() : this(new JqGridDataConfiguration())
        {
        }

        public JqGridData(JqGridDataConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public IEnumerable<object> Rows { get; set; }

        [JsonIgnore]
        public JqGridDataConfiguration Configuration
        {
            get { return _configuration; }
        }
    }
}