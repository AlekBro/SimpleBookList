
namespace SimpleBookList.DAL.Interfaces
{
    using System;

    using Entities;

    /// <summary>
    /// Unit Of Work Pattern interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets Repository for working with Books
        /// </summary>
        IRepository<Book> BooksRepository { get; }

        /// <summary>
        /// Gets Repository for working with Authors
        /// </summary>
        IRepository<Author> AuthorsRepository { get; }

        /// <summary>
        /// Save all changes in Database
        /// </summary>
        void Save();
    }
}
