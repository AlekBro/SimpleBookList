// -----------------------------------------------------------------------
// <copyright file="BookListService.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using AutoMapper;
    using DAL;
    using DAL.Interfaces;
    using Infrastructure;
    using Interfaces;
    using Models;

    /// <summary>
    /// Implement IBookListService - used for working with Books
    /// </summary>
    public class BookListService : IBookListService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService" /> class.
        /// </summary>
        /// <param name="unitOfWork">implementation instance of IUnitOfWork interface</param>
        public BookListService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWorkProperty = unitOfWork;
        }

        /// <summary>
        /// Gets Automapper Configuration
        /// </summary>
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        /// <summary>
        /// Gets or sets UnitOfWork class
        /// </summary>
        private IUnitOfWork UnitOfWorkProperty { get; set; }

        /// <summary>
        /// Get collection of all Books
        /// </summary>
        /// <returns>Book models collection</returns>
        public IEnumerable<BookViewModel> GetAllBooks()
        {
            IEnumerable<Book> allBooks = this.UnitOfWorkProperty.BooksRepository.GetAll();

            return this.Mapper.Map<IEnumerable<BookViewModel>>(allBooks);
        }

        /// <summary>
        /// Get one Book by his Id
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <returns>Found Book model</returns>
        public BookViewModel GetOneBook(int bookId)
        {
            Book bookItem = this.UnitOfWorkProperty.BooksRepository.Get(bookId);

            return this.Mapper.Map<BookViewModel>(bookItem);
        }

        /// <summary>
        /// Create new Book
        /// </summary>
        /// <param name="bookViewModel">new Book model</param>
        /// <returns>New Book model item</returns>
        public BookViewModel CreateBook(BookViewModel bookViewModel)
        {
            Book newBook = this.Mapper.Map<Book>(bookViewModel);

            newBook.Authors =
                this.UnitOfWorkProperty.AuthorsRepository.Find(x => bookViewModel.AuthorsIds.Contains(x.Id)).ToList();

            newBook = this.UnitOfWorkProperty.BooksRepository.Create(newBook);
            this.UnitOfWorkProperty.Save();

            BookViewModel newBookViewModel = this.Mapper.Map<BookViewModel>(newBook);
            return newBookViewModel;
        }

        /// <summary>
        /// Update existing Book
        /// </summary>
        /// <param name="bookViewModel">Book model for update</param>
        public void UpdateBook(BookViewModel bookViewModel)
        {
            Book bookItem = this.UnitOfWorkProperty.BooksRepository.Get(bookViewModel.Id);

            bookItem = this.Mapper.Map(bookViewModel, bookItem);

            bookItem.Authors.Clear();

            if (bookViewModel.AuthorsIds != null)
            {
                foreach (Author item in this.UnitOfWorkProperty
                    .AuthorsRepository.Find(x => bookViewModel.AuthorsIds.Contains(x.Id)).ToList())
                {
                    bookItem.Authors.Add(item);
                } 
            }
            else
            {
                bookItem.Authors = new List<Author>();
            }

            this.UnitOfWorkProperty.BooksRepository.Update(bookItem);

            this.UnitOfWorkProperty.Save();
        }

        /// <summary>
        /// Delete existing Book by his Id
        /// </summary>
        /// <param name="bookId">Book Id</param>
        public void DeleteBook(int bookId)
        {
            Book bookItem = this.UnitOfWorkProperty.BooksRepository.Get(bookId);

            if (bookItem != null)
            {
                this.UnitOfWorkProperty.BooksRepository.Delete(bookItem);
                this.UnitOfWorkProperty.Save();
            }
            else
            {
                throw new ArgumentException("Such Book is not found in the database!");
            }
        }

        /// <summary>
        /// Get All Authors from Database
        /// </summary>
        /// <returns>List of AuthorViewModel</returns>
        public IEnumerable<AuthorViewModel> GetAllAuthors()
        {
            IEnumerable<Author> allAuthors = this.UnitOfWorkProperty.AuthorsRepository.GetAll();
            return this.Mapper.Map<IEnumerable<AuthorViewModel>>(allAuthors);
        }

        /// <summary>
        /// Get one Author by his Id
        /// </summary>
        /// <param name="authorId">Author Id</param>
        /// <returns>Author View Model</returns>
        public AuthorViewModel GetOneAuthor(int authorId)
        {
            Author author = this.UnitOfWorkProperty.AuthorsRepository.Get(authorId);
            return this.Mapper.Map<AuthorViewModel>(author);
        }

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <param name="authorViewModel">new Author View Model</param>
        /// <returns>>new Author View Model</returns>
        public AuthorViewModel CreateAuthor(AuthorViewModel authorViewModel)
        {
            Author author = this.Mapper.Map<Author>(authorViewModel);
            author = this.UnitOfWorkProperty.AuthorsRepository.Create(author);
            this.UnitOfWorkProperty.Save();

            return this.Mapper.Map<AuthorViewModel>(author);
        }

        /// <summary>
        /// Update exist Author
        /// </summary>
        /// <param name="authorViewModel">Author View Model for update</param>
        public void UpdateAuthor(AuthorViewModel authorViewModel)
        {
            Author authorItem = this.UnitOfWorkProperty.AuthorsRepository.Get(authorViewModel.Id);

            authorItem = this.Mapper.Map(authorViewModel, authorItem);

            this.UnitOfWorkProperty.AuthorsRepository.Update(authorItem);
            this.UnitOfWorkProperty.Save();
        }

        /// <summary>
        /// Delete exist Author by his Id
        /// </summary>
        /// <param name="authorId">Author Id</param>
        public void DeleteAuthor(int authorId)
        {
            Author authorItem = this.UnitOfWorkProperty.AuthorsRepository.Get(authorId);

            if (authorItem != null)
            {
                this.UnitOfWorkProperty.AuthorsRepository.Delete(authorItem);
                this.UnitOfWorkProperty.Save();
            }
            else
            {
                throw new ArgumentException("Such Author is not found in the database!");
            }
        }

        /// <summary>
        /// Free any objects here.
        /// </summary>
        public void Dispose()
        {
            this.UnitOfWorkProperty.Dispose();
        }
    }
}
