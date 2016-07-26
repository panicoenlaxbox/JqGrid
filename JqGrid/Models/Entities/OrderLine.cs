namespace JqGrid.Models.Entities
{
    public class OrderLine : Entity
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Units { get; set; }
        public decimal Price { get; set; }
    }
}