
namespace SimpleBookList.BLL.Services
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using DAL;
    using DAL.Interfaces;
    using Interfaces;
    using Models;
    using Infrastructure;
    /// <summary>
    /// Implement IBookListService - used for working with Books
    /// </summary>
    public class BookListService : IBookListService
    {
        /// <summary>
        /// Initializes static members of the <see cref="BookListService" /> class.
        /// </summary>
        static BookListService()
        {


            /*
            MapperConfiguration bookToBookViewModelConfig = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookViewModel>());
            MapperBookToBookViewModel = bookToBookViewModelConfig.CreateMapper();

            MapperConfiguration BookViewModelToBookConfig = new MapperConfiguration(cfg => cfg.CreateMap<BookViewModel, Book>());
            MapperBookViewModelToBook = BookViewModelToBookConfig.CreateMapper();
            */
        }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService" /> class.
        /// </summary>
        /// <param name="unitOfWork">implementation instance of IUnitOfWork interface</param>
        public BookListService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWorkProperty = unitOfWork;
            
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

            // !MY! Exception on starting!
            return Mapper.Map<IEnumerable<BookViewModel>>(allBooks);
        }

        /// <summary>
        /// Get one Book by his Id
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <returns>Found Book model</returns>
        public BookViewModel GetOneBook(int bookId)
        {
            Book bookItem = this.UnitOfWorkProperty.BooksRepository.Get(bookId);

            return Mapper.Map<BookViewModel>(bookItem);
        }

        /// <summary>
        /// Create new Book
        /// </summary>
        /// <param name="BookViewModel">new Book model</param>
        /// <returns>New Book model item</returns>
        public BookViewModel CreateBook(BookViewModel BookViewModel)
        {
            Book newBook = Mapper.Map<Book>(BookViewModel);
            newBook = this.UnitOfWorkProperty.BooksRepository.Create(newBook);
            this.UnitOfWorkProperty.Save();

            BookViewModel newBookViewModel = Mapper.Map<BookViewModel>(newBook);
            return newBookViewModel;
        }

        /// <summary>
        /// Update existing Book
        /// </summary>
        /// <param name="BookViewModel">Book model for update</param>
        public void UpdateBook(BookViewModel BookViewModel)
        {
            Book bookItem = Mapper.Map<Book>(BookViewModel);
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
                throw new Exception("Such an Book is not found in the database!");
            }
        }


        public IEnumerable<AuthorViewModel> GetAllAuthors()
        {
            IEnumerable<Author> allAuthors = this.UnitOfWorkProperty.AuthorsRepository.GetAll();
            return Mapper.Map<IEnumerable<AuthorViewModel>>(allAuthors);
        }

        public AuthorViewModel GetOneAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public AuthorViewModel CreateAuthor(AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor(AuthorViewModel authorViewModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorViewModel> GetAuthorsOfBook(int bookId)
        {
            throw new NotImplementedException();
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
