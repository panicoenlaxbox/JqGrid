using System;
using System.Collections.Generic;

namespace JqGrid.Models
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(int pageIndex, int pageSize, IEnumerable<T> result, int totalCount)
        {
            Result = result;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public IEnumerable<T> Result { get; private set; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        public int TotalPageCount
        {
            get { return (int) Math.Ceiling(TotalCount/(double) PageSize); }
        }

        public bool HasPreviousPage
        {
            get { return PageIndex > 1; }
        }

        public bool HasNextPage
        {
            get { return PageIndex < TotalPageCount; }
        }
    }
}