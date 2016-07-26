using System.Linq;
using JqGrid.Models;

namespace JqGrid.Infrastructure
{
    public static class JqGridExtensions
    {
        public static PaginatedConfiguration GetPaginatedConfiguration(this JqGrid jqGrid)
        {
            return new PaginatedConfiguration(jqGrid.Page, jqGrid.Rows);
        }

        public static string SortExpression(this JqGrid jqGrid)
        {
            if (!jqGrid.Sort.Any())
            {
                return null;
            }
            if (jqGrid.Sort.Count() == 1)
            {
                var sort = jqGrid.Sort.First();
                return string.Format("{0} {1}", sort.Sort, sort.Order.ToString().ToUpper());
            }
            else
            {
                // TODO
                return null;
            }
        }

        public static JqGridData Data<T>(this JqGrid jqGrid, PaginatedResult<T> paginatedResult)
            where T : class
        {
            return new JqGridData
            {
                Total = paginatedResult.TotalPageCount,
                Page = paginatedResult.PageIndex,
                Records = paginatedResult.PageSize,
                Rows = paginatedResult.Result
            };
        }
    }
}