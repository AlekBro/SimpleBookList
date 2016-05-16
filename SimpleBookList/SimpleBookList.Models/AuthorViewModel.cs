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
        /// Number of Books of this Author
        /// </summary>
        public int BooksNumber { get; private set; }

        /// <summary>
        /// Author full name
        /// </summary>
        public string Name
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
