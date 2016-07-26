namespace JqGrid.Models.Entities
{
    public class Address : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}