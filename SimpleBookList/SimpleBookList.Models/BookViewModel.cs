﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookList.Models
{
    public class BookViewModel
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
        public int Pages { get; set; }

        /// <summary>
        /// Gets or sets Book rating
        /// </summary>
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets all authors of this book
        /// </summary>
        public virtual ICollection<AuthorViewModel> Authors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookViewModel" /> class
        /// </summary>
        public BookViewModel()
        {
            Authors = new List<AuthorViewModel>();
        }



    }
}