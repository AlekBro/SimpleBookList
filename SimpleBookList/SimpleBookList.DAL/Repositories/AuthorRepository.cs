
namespace SimpleBookList.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    //using EF;
    //using Entities;
    using Interfaces;

    /// <summary>
    /// Implementation of Repository pattern interface
    /// </summary>
    public class AuthorRepository : IRepository<Author>
    {
        /// <summary>
        /// Context for interacting with Database
        /// </summary>
        private DatabaseEntities context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository" /> class.
        /// </summary>
        /// <param name="context">Context for interacting with Database</param>
        public AuthorRepository(DatabaseEntities context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all Authors from Database
        /// </summary>
        /// <returns>All Authors list</returns>
        public IEnumerable<Author> GetAll()
        {
            return this.context.Authors;
        }

        /// <summary>
        /// Get one Author by his Id in Database
        /// </summary>
        /// <param name="itemId">Author id</param>
        /// <returns>Found Author</returns>
        public Author Get(int itemId)
        {
            return this.context.Authors.Find(itemId);
        }

        /// <summary>
        /// Find Authors in database
        /// </summary>
        /// <param name="predicate">Predicate for searching</param>
        /// <returns>Collection of found items</returns>
        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            return this.context.Authors.Where(predicate);
        }

        /// <summary>
        ///  Create new Author in Database
        /// </summary>
        /// <param name="item">new Author</param>
        /// <returns>Author item</returns>
        public Author Create(Author item)
        {
            this.context.Authors.Add(item);
            return item;
        }

        /// <summary>
        /// Update Author in database
        /// </summary>
        /// <param name="item">Author for update</param>
        public void Update(Author item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        ///  Delete Author
        /// </summary>
        /// <param name="item">Author for deleting</param>
        public void Delete(Author item)
        {
            this.context.Authors.Remove(item);
        }
    }
}
