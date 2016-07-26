using System.Collections.Generic;

namespace JqGrid.Models.Entities
{
    public class OrderQuestion : Entity
    {
        public string Question { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<OrderAnswer> Answers { get; set; }
    }
}