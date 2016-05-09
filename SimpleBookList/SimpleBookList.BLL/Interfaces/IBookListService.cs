
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
        /// <param name="BookViewModel">new Book model</param>
        /// <returns>New Book model item</returns>
        BookViewModel CreateBook(BookViewModel BookViewModel);

        /// <summary>
        /// Update existing Book
        /// </summary>
        /// <param name="BookViewModel">Book model for update</param>
        void UpdateBook(BookViewModel BookViewModel);

        /// <summary>
        /// Delete existing Book
        /// </summary>
        /// <param name="bookId">Book Id for delete</param>
        void DeleteBook(int bookId);

        //===============================================================================================

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
        /// <param name="AuthorViewModel">Author model for update</param>
        void UpdateAuthor(AuthorViewModel authorViewModel);

        /// <summary>
        /// Delete existing Author
        /// </summary>
        /// <param name="authorId">Author Id for delete</param>
        void DeleteAuthor(int authorId);



        /// <summary>
        ///  Get collection of all Authors for this book
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <returns>All Authors collection of Book</returns>
        IEnumerable<AuthorViewModel> GetAuthorsOfBook(int bookId);



        /// <summary>
        /// Free any objects here.
        /// </summary>
        void Dispose();
    }
}
