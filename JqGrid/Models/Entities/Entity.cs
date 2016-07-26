using System.ComponentModel.DataAnnotations.Schema;

namespace JqGrid.Models.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        [NotMapped]
        public State State { get; set; }
    }
}