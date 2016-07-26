namespace JqGrid.Models.Services
{
    public interface ICustomersService
    {
        PaginatedResult<CustomerDTO> GetPaginated(string sortExpression, PaginatedConfiguration pagination);
    }
}