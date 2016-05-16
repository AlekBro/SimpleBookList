// -----------------------------------------------------------------------
// <copyright file="AuthorViewModel.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;

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
        /// Gets Number of Books of this Author
        /// </summary>
        public int BooksNumber { get; private set; }

        /// <summary>
        /// Gets Author full name
        /// </summary>
        public string Name
        {
            get
            {
                StringBuilder line = new StringBuilder(this.FirstName);
                line.Append(' ');
                line.Append(this.LastName);
                return line.ToString();
            }
        }
    }
}
