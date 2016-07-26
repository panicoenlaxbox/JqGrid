namespace JqGrid.Models.Entities
{
    public class PaymentMethod : Entity
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}