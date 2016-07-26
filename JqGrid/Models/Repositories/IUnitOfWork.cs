using JqGrid.Models.Entities;

namespace JqGrid.Models.Repositories
{
    public interface IUnitOfWork
    {
        ShopContext Context { get; }
        void Save();
    }
}