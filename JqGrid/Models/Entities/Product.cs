using System.Collections.Generic;

namespace JqGrid.Models.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderLine> Lines { get; set; }
        public bool Discontinued { get; set; }
    }
}