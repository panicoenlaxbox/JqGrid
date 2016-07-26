using System.Linq;

namespace JqGrid.Models.Repositories
{
    public static class QueryableExtensions
    {
        public static PaginatedResult<T> Paginate<T>(this IQueryable<T> query,
            PaginatedConfiguration pagination)
        {
            var totalCount = query.Count();
            var pageIndex = pagination.PageIndex;
            var countToSkip = (pageIndex < 1 ? 0 : pageIndex - 1)*pageIndex;
            var pageSize = pagination.PageSize;
            var result = query.Skip(countToSkip).Take(pageSize).ToList();
            return new PaginatedResult<T>(pageIndex, pageSize, result, totalCount);
        }
    }
}