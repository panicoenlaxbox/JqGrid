using System.Collections.Generic;

namespace JqGrid.Infrastructure
{
    public class JqGrid
    {
        public JqGrid()
        {
            Pages = 1;
        }

        public int Rows { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
        public IEnumerable<JqGridSort> Sort { get; set; }
    }
}