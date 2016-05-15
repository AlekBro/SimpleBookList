
namespace SimpleBookList.UI.Utils
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls; //For SortBy method

    public class AuthorResultSet
    {
        public List<AuthorViewModel> GetResult(string search, string sortOrder, int start, int length,
            List<AuthorViewModel> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).SortBy(sortOrder).Skip(start).Take(length).ToList();
        }

        public int Count(string search, List<AuthorViewModel> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).Count();
        }


        private IQueryable<AuthorViewModel> FilterResult(string search, List<AuthorViewModel> dtResult, List<string> columnFilters)
        {
            IQueryable<AuthorViewModel> results = dtResult.AsQueryable();

            results = results.Where(p => (search == null ||
            (p.FirstName != null && p.FirstName.ToLower().Contains(search.ToLower()) ||
            p.LastName != null && p.LastName.ToLower().Contains(search.ToLower()) ||
             p.BooksNumber.ToString().ToLower().Contains(search.ToLower())

                && (columnFilters[0] == null || (p.FirstName != null && p.FirstName.ToLower().Contains(columnFilters[0].ToLower())))
                && (columnFilters[1] == null || (p.LastName != null && p.LastName.ToLower().Contains(columnFilters[1].ToLower())))
                && (columnFilters[2] == null || (p.BooksNumber.ToString().ToLower().Contains(columnFilters[2].ToLower())))

                )
                ));

            return results;
        }
    }
}


