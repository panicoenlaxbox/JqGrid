using System.Data.Entity;

namespace JqGrid.Models.Entities
{
    public static class DbContextExtensions
    {
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<Entity>())
            {
                entry.State = entry.Entity.State.ConvertToEntityState();
            }
        }
    }
}