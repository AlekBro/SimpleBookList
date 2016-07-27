// -----------------------------------------------------------------------
// <copyright file="AuthorResultSet.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.UI.Utils
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls; // For SortBy method

    using Models;

    /// <summary>
    /// Author List sorting, searching and filtering
    /// </summary>
    public class AuthorResultSet
    {
        /// <summary>
        /// Get filtering result
        /// </summary>
        /// <param name="search">Search text</param>
        /// <param name="sortOrder">Sort Order</param>
        /// <param name="start">Start position</param>
        /// <param name="length">Row number</param>
        /// <param name="dataResult">Input Data</param>
        /// <param name="columnFilters">Column Filters</param>
        /// <returns>List of Author View Model</returns>
        public List<AuthorViewModel> GetResult(string search, string sortOrder, int start, int length, List<AuthorViewModel> dataResult, List<string> columnFilters)
        {
            return this.FilterResult(search, dataResult, columnFilters).SortBy(sortOrder).Skip(start).Take(length).ToList();
        }

        /// <summary>
        /// Counting result
        /// </summary>
        /// <param name="search">search text</param>
        /// <param name="dataResult">Input Data</param>
        /// <param name="columnFilters">Column Filters</param>
        /// <returns>Filter Result Count</returns>
        public int Count(string search, List<AuthorViewModel> dataResult, List<string> columnFilters)
        {
            return this.FilterResult(search, dataResult, columnFilters).Count();
        }

        /// <summary>
        /// Searching in List
        /// </summary>
        /// <param name="search">search text</param>
        /// <param name="dataResult">Input Data</param>
        /// <param name="columnFilters">Column Filters</param>
        /// <returns>Searching result List</returns>
        private IQueryable<AuthorViewModel> FilterResult(string search, List<AuthorViewModel> dataResult, List<string> columnFilters)
        {
            IQueryable<AuthorViewModel> results = dataResult.AsQueryable();

            results = results.Where(p => (search == null || (p.FirstName != null && p.FirstName.ToLower().Contains(search.ToLower()) || p.LastName != null && p.LastName.ToLower().Contains(search.ToLower()) || p.BooksNumber.ToString().ToLower().Contains(search.ToLower()) && (columnFilters[0] == null || (p.FirstName != null && p.FirstName.ToLower().Contains(columnFilters[0].ToLower()))) && (columnFilters[1] == null || (p.LastName != null && p.LastName.ToLower().Contains(columnFilters[1].ToLower()))) && (columnFilters[2] == null || (p.BooksNumber.ToString().ToLower().Contains(columnFilters[2].ToLower()))))));

            return results;
        }
    }
}
