// -----------------------------------------------------------------------
// <copyright file="DTParameters.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models.DataTableModels
{
    /// <summary>
    /// The parameters sent by jQuery DataTables in AJAX queries.
    /// </summary>
    public class DTParameters
    {
        /// <summary>
        /// Gets or sets Draw counter.
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// Gets or sets An array defining all columns in the table.
        /// </summary>
        public DTColumn[] Columns { get; set; }

        /// <summary>
        /// Gets or sets An array defining how many columns are being ordering upon - i.e. if the array length is 1, then a single column sort is being performed, otherwise a multi-column sort is being performed.
        /// </summary>
        public DTOrder[] Order { get; set; }

        /// <summary>
        /// Gets or sets Paging first record indicator.
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Gets or sets Number of records that the table can display in the current draw.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets Global search value. To be applied to all columns which have searchable as true.
        /// </summary>
        public DTSearch Search { get; set; }

        /// <summary>
        /// Gets Custom column that is used to further sort on the first Order column.
        /// </summary>
        public string SortOrder
        {
            get
            {
                return this.Columns != null && this.Order != null && this.Order.Length > 0
                    ? (this.Columns[this.Order[0].Column].Data + (this.Order[0].Dir == DTOrderDir.DESC ? " " + this.Order[0].Dir : string.Empty))
                    : null;
            }
        }
    }
}
