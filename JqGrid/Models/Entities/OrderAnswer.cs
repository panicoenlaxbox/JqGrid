namespace JqGrid.Models.Entities
{
    public class OrderAnswer : Entity
    {
        public string Answer { get; set; }
        public int OrderQuestionId { get; set; }
        public virtual OrderQuestion OrderQuestion { get; set; }
    }
}