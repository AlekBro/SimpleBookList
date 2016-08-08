// -----------------------------------------------------------------------
// <copyright file="IBookListService.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.BLL.Interfaces
{
    using System.Collections.Generic;

    using Models;

    /// <summary>
    /// Service for CRUD operations with database
    /// </summary>
    public interface IBookListService
    {
        /// <summary>
        ///  Get collection of all Books
        /// </summary>
        /// <returns>All Books collection</returns>
        IEnumerable<BookViewModel> GetAllBooks();

        /// <summary>
        /// Get one Book by his Id
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <returns>Book model</returns>
        BookViewModel GetOneBook(int bookId);

        /// <summary>
        /// Create new Book
        /// </summary>
        /// <param name="bookViewModel">new Book model</param>
        /// <returns>New Book model item</returns>
        BookViewModel CreateBook(BookViewModel bookViewModel);

        /// <summary>
        /// Update existing Book
        /// </summary>
        /// <param name="bookViewModel">Book model for update</param>
        void UpdateBook(BookViewModel bookViewModel);

        /// <summary>
        /// Delete existing Book
        /// </summary>
        /// <param name="bookId">Book Id for delete</param>
        void DeleteBook(int bookId);

        /// <summary>
        ///  Get collection of all Authors
        /// </summary>
        /// <returns>All Authors collection</returns>
        IEnumerable<AuthorViewModel> GetAllAuthors();

        /// <summary>
        /// Get one Author by his Id
        /// </summary>
        /// <param name="authorId">Author Id</param>
        /// <returns>Book model</returns>
        AuthorViewModel GetOneAuthor(int authorId);

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <param name="authorViewModel">new Author model</param>
        /// <returns>New Author model item</returns>
        AuthorViewModel CreateAuthor(AuthorViewModel authorViewModel);

        /// <summary>
        /// Update existing Author
        /// </summary>
        /// <param name="authorViewModel">Author model for update</param>
        void UpdateAuthor(AuthorViewModel authorViewModel);

        /// <summary>
        /// Delete existing Author
        /// </summary>
        /// <param name="authorId">Author Id for delete</param>
        void DeleteAuthor(int authorId);

        /// <summary>
        /// Create new xlsx file with all Books
        /// </summary>
        /// <param name="fullFilePath">Path for file wuth file name</param>
        /// <param name="service">Book list service</param>
        /// <returns>New file bytes for download</returns>
        byte[] ExportBooksToFile(string fullFilePath);

        /// <summary>
        /// Free any objects here.
        /// </summary>
        void Dispose();
    }
}
