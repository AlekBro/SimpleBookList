// -----------------------------------------------------------------------
// <copyright file="DTSearch.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models.DataTableModels
{
    /// <summary>
    /// A search, as sent by jQuery DataTables when doing AJAX queries.
    /// </summary>
    public class DTSearch
    {
        /// <summary>
        /// Gets or sets Global search value. To be applied to all columns which have searchable as true.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets true if the global filter should be treated as a regular expression for advanced searching, false otherwise.
        /// </summary>
        public bool Regex { get; set; }
    }
}
