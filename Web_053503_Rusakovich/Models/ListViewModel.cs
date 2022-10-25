using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Web_053503_Rusakovich.Models
{
    public class ListViewModel<T> : List<T> where T : class
    {
        public int currentPage { get; set; }
        public int totalPages { get; set; }

        private ListViewModel(IEnumerable<T> items, int currentPage, int totalPages) : base(items)
        {
            this.currentPage = currentPage;
            this.totalPages = totalPages;
        }

        public static ListViewModel<T> GetModel(IEnumerable<T> list,
            int current,
            int itemsPerPages)
        {
            var items = list.Skip((current - 1) * itemsPerPages)
               .Take(itemsPerPages).ToList();
            var total = (int)Math.Ceiling((double)list.Count() / itemsPerPages);
            return new ListViewModel<T>(items, current, total);
        }
    }
}