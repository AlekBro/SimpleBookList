
namespace SimpleBookList.DAL.EF
{
    using System;

    using System.Data.Entity;
    using Entities;
    using System.Collections.Generic;
    /// <summary>
    /// Removes and recreates all tables in the database each time when the application is started
    /// </summary>
    public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        /// <summary>
        /// Adds the test data.
        /// </summary>
        /// <param name="context">Database Context</param>
        protected override void Seed(DatabaseContext context)
        {

            Author author1 = new Author { FirstName = "Adam", LastName = "Freeman" };
            Author author2 = new Author { FirstName = "Jon", LastName = "Galloway" };
            Author author3 = new Author { FirstName = "Brad", LastName = "Wilson" };
            Author author4 = new Author { FirstName = "Scott", LastName = "Allen" };
            Author author5 = new Author { FirstName = "David", LastName = "Matson" };

            Author author6 = new Author { FirstName = "Jeff", LastName = "Atwood" };
            Author author7 = new Author { FirstName = "Wyatt", LastName = "Barnett" };
            Author author8 = new Author { FirstName = "Phil", LastName = "Haack" };

            Author author9 = new Author { FirstName = "Andrew", LastName = "Troelsen" };
            Author author10 = new Author { FirstName = "Philip", LastName = "Japikse" };

            Author author11 = new Author { FirstName = "Jamie", LastName = "Munro" };

            Author author12 = new Author { FirstName = "Arnaud", LastName = "Weil" };

            Author author13 = new Author { FirstName = "Simone", LastName = "Chiaretta" };

            Author author14 = new Author { FirstName = "Jess", LastName = "Chadwick" };
            Author author15 = new Author { FirstName = "Todd", LastName = "Snyder" };
            Author author16 = new Author { FirstName = "Hrusikesh", LastName = "Panda" };
             

            Book book1 = new Book { Name = "Pro ASP.NET MVC 5 Platform", ReleaseDate = new DateTime(2014, 4, 18), Pages = 428, Rating = 0, Authors = new List<Author> { author1 } };
            Book book2 = new Book { Name = "Pro ASP.NET MVC 5 (Expert's Voice in ASP.Net)", ReleaseDate = new DateTime(2013, 12, 23), Pages = 832, Rating = 0, Authors = new List<Author> { author1 } };
            Book book3 = new Book { Name = "Professional ASP.NET MVC 5", ReleaseDate = new DateTime(2014, 8, 4), Pages = 624, Rating = 0, Authors = new List<Author> { author2, author3, author4, author5 } };
            Book book4 = new Book { Name = "The ASP.NET 2.0 Anthology: 101 Essential Tips, Tricks & Hacks", ReleaseDate = new DateTime(2007, 9, 18), Pages = 500, Rating = 0, Authors = new List<Author> { author4, author6, author7, author2, author8 } };
            Book book5 = new Book { Name = "C# 6.0 and the .NET 4.6 Framework", ReleaseDate = new DateTime(2015, 11, 8), Pages = 1625, Rating = 0, Authors = new List<Author> { author9, author10 } };

            Book book6 = new Book
            {
                Name = "ASP.NET MVC 5 with Bootstrap and Knockout.js: Building Dynamic, Responsive Web Applications",
                ReleaseDate = new DateTime(2015, 5, 31),
                Pages = 278,
                Rating = 0,
                Authors = new List<Author> { author11 }
            };

            Book book7 = new Book
            {
                Name = "Knockout.js: Building Dynamic Client-Side Web Applications",
                ReleaseDate = new DateTime(2015, 1, 3),
                Pages = 102,
                Rating = 0,
                Authors = new List<Author> { author11 }
            };

            Book book8 = new Book
            {
                Name = "Learn ASP.NET MVC",
                ReleaseDate = new DateTime(2016, 1, 8),
                Pages = 150,
                Rating = 0,
                Authors = new List<Author> { author12 }
            };

            Book book9 = new Book
            {
                Name = "Front-end Development with ASP.NET MVC 6, AngularJS, and Bootstrap",
                ReleaseDate = new DateTime(2016, 9, 26),
                Pages = 240,
                Rating = 0,
                Authors = new List<Author> { author13 }
            };
            Book book10 = new Book
            {
                Name = "Pro AngularJS (Expert's Voice in Web Development)",
                ReleaseDate = new DateTime(2014, 3, 27),
                Pages = 688,
                Rating = 0,
                Authors = new List<Author> { author1 }
            };

            Book book11 = new Book
            {
                Name = "Pro ASP.NET 4.5 in C#",
                ReleaseDate = new DateTime(2013, 7, 15),
                Pages = 1228,
                Rating = 0,
                Authors = new List<Author> { author1 }
            };
            Book book12 = new Book
            {
                Name = "Expert ASP.NET Web API 2 for MVC Developers",
                ReleaseDate = new DateTime(2015, 8, 15),
                Pages = 688,
                Rating = 0,
                Authors = new List<Author> { author1 }
            };
            Book book13 = new Book
            {
                Name = "Pro ASP.NET MVC 4",
                ReleaseDate = new DateTime(2013, 1, 16),
                Pages = 756,
                Rating = 0,
                Authors = new List<Author> { author1 }
            };
            Book book14 = new Book
            {
                Name = "Programming ASP.NET MVC 4: Developing Real-World Web Applications with ASP.NET MVC",
                ReleaseDate = new DateTime(2012, 10, 6),
                Pages = 492,
                Rating = 0,
                Authors = new List<Author> { author14, author15, author16 }
            };
            Book book15 = new Book
            {
                Name = "Programming Razor",
                ReleaseDate = new DateTime(2011, 9, 25),
                Pages = 120,
                Rating = 0,
                Authors = new List<Author> { author14 }
            };
            /*
            Book book5 = new Book
            {
                Name = "",
                ReleaseDate = new DateTime(2015, 11, 8),
                Pages = 1625,
                Rating = 0,
                Authors = new List<Author> { author9, author10 }
            };
            */

            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book4);
            context.Books.Add(book5);
            context.Books.Add(book6);
            context.Books.Add(book7);
            context.Books.Add(book8);
            context.Books.Add(book9);
            context.Books.Add(book10);
            context.Books.Add(book11);
            context.Books.Add(book12);
            context.Books.Add(book13);
            context.Books.Add(book14);
            context.Books.Add(book15);

            context.SaveChanges();
        }
    }
}
