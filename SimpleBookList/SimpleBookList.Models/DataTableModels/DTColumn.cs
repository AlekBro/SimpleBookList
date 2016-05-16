// -----------------------------------------------------------------------
// <copyright file="DTColumn.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models.DataTableModels
{
    /// <summary>
    /// A jQuery DataTables column.
    /// </summary>
    public class DTColumn
    {
        /// <summary>
        /// Gets or sets Column's data source, as defined by columns.data.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets Column's name, as defined by columns.name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a Flag to indicate if this column is searchable (true) or not (false).
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// Gets or sets Flag to indicate if this column is orderable (true) or not (false).
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// Gets or sets Specific search value.
        /// </summary>
        public DTSearch Search { get; set; }
    }
}
