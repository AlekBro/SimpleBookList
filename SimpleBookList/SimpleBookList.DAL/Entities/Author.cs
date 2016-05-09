
namespace SimpleBookList.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Author model class for EntityFramework
    /// </summary>
    public class Author
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
        /// Gets or sets all books of this author
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Author" /> class
        /// </summary>
        public Author()
        {
            Books = new List<Book>();
        }
    }
}
