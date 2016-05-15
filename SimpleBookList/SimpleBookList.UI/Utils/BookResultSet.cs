
namespace SimpleBookList.UI.Utils
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls; //For SortBy method

    public class BookResultSet
    {
        public List<BookViewModel> GetResult(string search, string sortOrder, int start, int length,
            List<BookViewModel> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).SortBy(sortOrder).Skip(start).Take(length).ToList();
        }

        public int Count(string search, List<BookViewModel> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).Count();
        }


        private IQueryable<BookViewModel> FilterResult(string search, List<BookViewModel> dtResult, List<string> columnFilters)
        {
            IQueryable<BookViewModel> results = dtResult.AsQueryable();

            results = results.Where(p => (search == null ||
            (p.Name != null && p.Name.ToLower().Contains(search.ToLower()) ||
            p.ReleaseDate != null && p.ReleaseDate.ToString().ToLower().Contains(search.ToLower()) ||
             p.Pages.ToString().ToLower().Contains(search.ToLower()) ||
             p.Rating.ToString().ToLower().Contains(search.ToLower()) ||
                p.AuthorsNames != null && p.AuthorsNames.ToLower().Contains(search.ToLower())

                && (columnFilters[0] == null || (p.Name != null && p.Name.ToLower().Contains(columnFilters[0].ToLower())))
                && (columnFilters[1] == null || (p.ReleaseDate != null && p.ReleaseDate.ToString().ToLower().Contains(columnFilters[1].ToLower())))
                && (columnFilters[2] == null || (p.Pages.ToString().ToLower().Contains(columnFilters[2].ToLower())))
                && (columnFilters[3] == null || (p.Rating.ToString().ToLower().Contains(columnFilters[3].ToLower())))
                && (columnFilters[4] == null || (p.AuthorsNames != null && p.AuthorsNames.ToLower().Contains(columnFilters[4].ToLower())))

                )
                ));

            return results;
        }
    }
}


