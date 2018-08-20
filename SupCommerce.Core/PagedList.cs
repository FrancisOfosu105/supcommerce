using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SupCommerce.Core
{
    public class PagedList<T> : IPagedList<T> where T : class
    {
        private readonly IEnumerable<T> _items;

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public int NextPage
        {
            get
            {
                if (!HasNextPage)
                {
                    throw new InvalidOperationException();
                }

                return Page + 1;
            }
        }

        public int PreviousPage
        {
            get
            {
                if (!HasPreviousPage)
                {
                    throw new InvalidOperationException();
                }

                return Page - 1;
            }
        }

        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

        public PagedList(IEnumerable<T> items, int totalCount, int page, int pageSize)
        {
            _items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int) Math.Ceiling((float) TotalCount / PageSize);
            HasNextPage = Page < TotalPages;
            HasPreviousPage = Page > 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}