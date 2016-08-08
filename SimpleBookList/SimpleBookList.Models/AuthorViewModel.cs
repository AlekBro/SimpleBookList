// -----------------------------------------------------------------------
// <copyright file="AuthorViewModel.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Author View Model
    /// </summary>
    public class AuthorViewModel
    {
        /// <summary>
        /// Gets or sets the primary key property
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Author first name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Author last name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Number of Books of this Author
        /// </summary>
        public int BooksNumber { get; set; }

        /// <summary>
        /// Gets Author full name
        /// </summary>
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        /// <summary>
        /// Gets or sets right for update and delete author for current user
        /// </summary>
        public bool IsUserHasRightForEdit { get; set; }
    }
}
