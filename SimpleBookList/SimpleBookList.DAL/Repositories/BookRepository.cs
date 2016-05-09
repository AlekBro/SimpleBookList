
namespace SimpleBookList.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using EF;
    using Entities;
    using Interfaces;

    /// <summary>
    /// Implementation of Repository pattern interface
    /// </summary>
    public class BookRepository : IRepository<Book>
    {
        /// <summary>
        /// Context for interacting with Database
        /// </summary>
        private DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository" /> class.
        /// </summary>
        /// <param name="context">Context for interacting with Database</param>
        public BookRepository(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all Books from Database
        /// </summary>
        /// <returns>All Books list</returns>
        public IEnumerable<Book> GetAll()
        {
            return this.context.Books;
        }

        /// <summary>
        /// Get one Book by his Id in Database
        /// </summary>
        /// <param name="itemId">Book id</param>
        /// <returns>Found Book</returns>
        public Book Get(int itemId)
        {
            return this.context.Books.Find(itemId);
        }

        /// <summary>
        /// Find Books in database
        /// </summary>
        /// <param name="predicate">Predicate for searching</param>
        /// <returns>Collection of found items</returns>
        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return this.context.Books.Where(predicate);
        }

        /// <summary>
        ///  Create new Book in Database
        /// </summary>
        /// <param name="item">new Book</param>
        /// <returns>Book item</returns>
        public Book Create(Book item)
        {
            this.context.Books.Add(item);
            return item;
        }

        /// <summary>
        /// Update Book in database
        /// </summary>
        /// <param name="item">Book for update</param>
        public void Update(Book item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        ///  Delete Book
        /// </summary>
        /// <param name="item">Book for deleting</param>
        public void Delete(Book item)
        {
            this.context.Books.Remove(item);
        }
    }
}
