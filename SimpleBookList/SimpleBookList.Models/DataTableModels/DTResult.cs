// -----------------------------------------------------------------------
// <copyright file="DTResult.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models.DataTableModels
{
    using System.Collections.Generic;

    /// <summary>
    /// A full result, as understood by jQuery DataTables.
    /// </summary>
    /// <typeparam name="T">The data type of each row.</typeparam>
    public class DTResult<T>
    {
        /// <summary>
        /// Gets or sets The draw counter that this object is a response to - from the draw parameter sent as part of the data request.
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// Gets or sets Total records, before filtering (i.e. the total number of records in the database)
        /// </summary>
        public int RecordsTotal { get; set; }

        /// <summary>
        /// Gets or sets Total records, after filtering (i.e. the total number of records after filtering has been applied - not just the number of records being returned for this page of data).
        /// </summary>
        public int RecordsFiltered { get; set; }

        /// <summary>
        /// Gets or sets The data to be displayed in the table.
        /// </summary>
        public List<T> Data { get; set; }
    }
}
