using AutoMapper.QueryableExtensions;
using JqGrid.Models.Entities;
using JqGrid.Models.Repositories;

namespace JqGrid.Models.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomersService(IUnitOfWork unitOfWork, ICustomersRepository customersRepository)
        {
            _unitOfWork = unitOfWork;
            _customersRepository = customersRepository;
        }

        public PaginatedResult<CustomerDTO> GetPaginated(string sortExpression,
            PaginatedConfiguration pagination)
        {
            AutoMapper.Mapper.CreateMap<Customer, CustomerDTO>();
            return _customersRepository.GetAll(sortExpression).ProjectTo<CustomerDTO>().Paginate(pagination);
        }
    }
}