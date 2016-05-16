﻿// -----------------------------------------------------------------------
// <copyright file="BookResultSet.cs" company="AlekBro">
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
    /// Book List sorting, searching and filtering
    /// </summary>
    public class BookResultSet
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
        /// <returns>List of Book View Model</returns>
        public List<BookViewModel> GetResult(string search, string sortOrder, int start, int length, List<BookViewModel> dataResult, List<string> columnFilters)
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
        public int Count(string search, List<BookViewModel> dataResult, List<string> columnFilters)
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
        private IQueryable<BookViewModel> FilterResult(string search, List<BookViewModel> dataResult, List<string> columnFilters)
        {
            IQueryable<BookViewModel> results = dataResult.AsQueryable();

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
                && (columnFilters[4] == null || (p.AuthorsNames != null && p.AuthorsNames.ToLower().Contains(columnFilters[4].ToLower()))))));

            return results;
        }
    }
}
