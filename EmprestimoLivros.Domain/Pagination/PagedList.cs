using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PagedSize { get; set; }
        public int TotalCount { get; set; }

        public PagedList(IEnumerable<T> items,int pageNumber, int pagedSize, int count)
        {
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count/ (double) pagedSize);
            PagedSize = pagedSize;
            TotalCount = count;
            AddRange(items);
        }

        public PagedList(IEnumerable<T> items, int currentPage, int totalPages, int pagedSize, int totalCount)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PagedSize = pagedSize;
            TotalCount = totalCount;
            AddRange(items);
        }
    }
}
