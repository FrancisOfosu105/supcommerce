using System.Collections.Generic;

namespace SupCommerce.Core
{
    public interface IPagedList<T> : IEnumerable<T> where T : class
    {
        int Page { get; set; }

        int PageSize { get; set; }

        int TotalCount { get; set; }

        int TotalPages { get; set; }

        int NextPage { get; }

        int PreviousPage { get; }


        bool HasNextPage { get; set; }

        bool HasPreviousPage { get; set; }
    }
}