// -----------------------------------------------------------------------
// <copyright file="DTRow.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models.DataTableModels
{
    /// <summary>
    /// The additional columns that you can send to jQuery DataTables for automatic processing.
    /// </summary>
    public abstract class DTRow
    {
        /// <summary>
        /// Gets the ID property of the dt-tag tr node to this value
        /// </summary>
        public virtual string DTRowId
        {
            get { return null; }
        }

        /// <summary>
        /// Gets this class to the dt-tag tr node
        /// </summary>
        public virtual string DTRowClass
        {
            get { return null; }
        }

        /// <summary>
        /// Gets this data property to the row's dt-tag tr node allowing abstract data to be added to the node, using the HTML5 data-* attributes.
        /// </summary>
        public virtual object DTRowData
        {
            get { return null; }
        }
    }
}
