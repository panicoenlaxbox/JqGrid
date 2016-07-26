using System.Linq;
using JqGrid.Models.Entities;

namespace JqGrid.Models.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IGenericRepository<Customer> _genericRepository;

        public CustomersRepository(IGenericRepository<Customer> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IQueryable<Customer> GetAll(string sortExpression)
        {
            return _genericRepository.GetAll(null, null, sortExpression);
        }
    }
}