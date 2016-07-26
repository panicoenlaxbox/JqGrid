using System.Linq;
using JqGrid.Models.Entities;

namespace JqGrid.Models.Repositories
{
    public interface ICustomersRepository
    {
        IQueryable<Customer> GetAll(string sortExpression);
    }
}