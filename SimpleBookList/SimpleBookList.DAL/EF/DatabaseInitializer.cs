
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


            Book book1 = new Book { Name = "Pro ASP.NET MVC 5 Platform", ReleaseDate = new DateTime(2014, 4, 18), Pages = 428, Rating = 0, Authors = new List<Author> { author1 } };
            Book book2 = new Book { Name = "Pro ASP.NET MVC 5 (Expert's Voice in ASP.Net)", ReleaseDate = new DateTime(2013, 12, 23), Pages = 832, Rating = 0, Authors = new List<Author> { author1 } };
            Book book3 = new Book { Name = "Professional ASP.NET MVC 5", ReleaseDate = new DateTime(2014, 8, 4), Pages = 624, Rating = 0, Authors = new List<Author> { author2, author3, author4, author5 } };
            Book book4 = new Book { Name = "The ASP.NET 2.0 Anthology: 101 Essential Tips, Tricks & Hacks", ReleaseDate = new DateTime(2007, 9, 18), Pages = 500, Rating = 0, Authors = new List<Author> { author4, author6, author7, author2, author8 } };
            Book book5 = new Book { Name = "C# 6.0 and the .NET 4.6 Framework", ReleaseDate = new DateTime(2015, 11, 8), Pages = 1625, Rating = 0, Authors = new List<Author> { author9, author10 } };


            context.SaveChanges();
        }
    }
}
