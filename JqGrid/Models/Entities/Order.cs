using System;
using System.Collections.Generic;

namespace JqGrid.Models.Entities
{
    public class Order : Entity
    {
        public DateTime CreatedDate { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<OrderLine> Lines { get; set; }
        public virtual ICollection<OrderQuestion> Questions { get; set; }
    }
}