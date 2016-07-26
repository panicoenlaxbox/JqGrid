using System;
using System.Collections.Generic;

namespace JqGrid.Models.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public DateTime? Birthday { get; set; }
    }
}