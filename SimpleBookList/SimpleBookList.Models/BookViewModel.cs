// -----------------------------------------------------------------------
// <copyright file="BookViewModel.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Attributes.Models;

    /// <summary>
    /// Book View Model
    /// </summary>
    public class BookViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookViewModel" /> class
        /// </summary>
        public BookViewModel()
        {
            this.Authors = new List<AuthorViewModel>();
        }

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
        [Display(Name = "Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets From date string
        /// </summary>
        public string FormattedReleaseDate
        {
            get
            {
                return this.ReleaseDate.ToString("MM/dd/yyyy");
            }
        }

        /// <summary>
        /// Gets or sets number of pages in this Book
        /// </summary>
        [Display(Name = "Pages")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Page number cannot be 0 or less.")]
        public int Pages { get; set; }

        /// <summary>
        /// Gets or sets Book rating
        /// </summary>
        [Display(Name = "Rating")]
        [Range(0, 10, ErrorMessage = "Rating is must be between 0 and 10")]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets Publisher name
        /// </summary>
        [Display(Name = "Publisher")]
        [StringLength(100)]
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets ISBN
        /// </summary>
        [Display(Name = "ISBN")]
        [RequiredIf("Publisher", ErrorMessage = "The ISBN field is required when Publisher was entered.")]
        [StringLength(100)]
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets all authors of this book
        /// </summary>
        public virtual ICollection<AuthorViewModel> Authors { get; set; }

        /// <summary>
        /// Gets or sets All Authors Ids
        /// </summary>
        public List<int> AuthorsIds { get; set; }

        /// <summary>
        /// Gets All Authors Names for search
        /// </summary>
        public string AuthorsNames
        {
            get
            {
                StringBuilder names = new StringBuilder();
                foreach (var item in this.Authors)
                {
                    names.Append(item.Name);
                    names.Append(", ");
                }

                if (names.Length > 0)
                {
                    names.Remove(names.Length - 2, 2);
                }

                return names.ToString();
            }
        }
    }
}
