
namespace SimpleBookList.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Book model class for EntityFramework
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the primary key property
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Book name
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets release date of Book
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets number of pages in this Book
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// Gets or sets Book rating
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets all authors of this book
        /// </summary>
        public virtual ICollection<Author> Authors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book" /> class
        /// </summary>
        public Book()
        {
            Authors = new List<Author>();
        }

    }
}
