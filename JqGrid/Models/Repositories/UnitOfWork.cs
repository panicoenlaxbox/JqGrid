using JqGrid.Models.Entities;

namespace JqGrid.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ShopContext context)
        {
            Context = context;
        }

        public ShopContext Context { get; }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}