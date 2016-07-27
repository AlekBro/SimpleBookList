using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SimpleBookList.BLL.Interfaces;
using SimpleBookList.Models;
using SimpleBookList.Models.DataTableModels;
using SimpleBookList.Models.Utils;

namespace SimpleBookList.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service :  IService
    {
        /// <summary>
        /// BookService class property
        /// </summary>
        private IBookListService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController" /> class.
        /// </summary>
        /// <param name="service">implementation instance of IBookService interface</param>
        public Service(IBookListService service)
        {
            this._service = service;
        }

        public List<BookViewModel> GetBookList()
        {
            List<BookViewModel> allBooks = this._service.GetAllBooks().ToList();

            return allBooks;
        }



        public DTResult<BookViewModel> GetBooks(DTParameters param)
        {

            List<string> columnSearch = new List<string>();

            foreach (var col in param.Columns)
            {
                columnSearch.Add(col.Search.Value);
            }

            List<BookViewModel> data = new BookResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, this._service.GetAllBooks(), columnSearch);

            int count = new BookResultSet().Count(param.Search.Value, this._service.GetAllBooks(), columnSearch);

            DTResult<BookViewModel> result = new DTResult<BookViewModel>
            {
                draw = param.Draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };


            return result;
        }


        public BookViewModel GetBookById(int bookId)
        {
            BookViewModel book = this._service.GetOneBook(bookId);

            return book;
        }

        public int? AddNewBook(BookViewModel newBook)
        {
            try
            {
                newBook = this._service.CreateBook(newBook);

                return newBook.Id;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        public bool DeleteBookById(int bookId)
        {
            BookViewModel book = this._service.GetOneBook(bookId);

            if (book != null)
            {
                try
                {
                    this._service.DeleteBook(bookId);
                }
                catch (Exception Ex)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public BookViewModel EditBook(BookViewModel inputBook)
        {
            BookViewModel book = this._service.GetOneBook(inputBook.Id);
            if (book != null)
            {
                try
                {
                    this._service.UpdateBook(inputBook);
                }
                catch (Exception Ex)
                {
                    return null;
                }

                return inputBook;
            }
            else
            {
                return null;
            }
        }




        public List<AuthorViewModel> GetAuthorList()
        {
            List<AuthorViewModel> allAuthors = this._service.GetAllAuthors().ToList();

            return allAuthors;
        }

        public DTResult<AuthorViewModel> GetAuthors(DTParameters param)
        {
            List<string> columnSearch = new List<string>();

            foreach (var col in param.Columns)
            {
                columnSearch.Add(col.Search.Value);
            }

            List<AuthorViewModel> data = new AuthorResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, this._service.GetAllAuthors(), columnSearch);

            int count = new AuthorResultSet().Count(param.Search.Value, this._service.GetAllAuthors(), columnSearch);

            DTResult<AuthorViewModel> result = new DTResult<AuthorViewModel>
            {
                draw = param.Draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return result;

        }


        public AuthorViewModel GetAuthorById(int authorId)
        {
            AuthorViewModel author = this._service.GetOneAuthor(authorId);

            return author;
        }

        public int? AddNewAuthor(AuthorViewModel newAuthor)
        {
            try
            {
                newAuthor = this._service.CreateAuthor(newAuthor);

                return newAuthor.Id;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        public bool DeleteAuthorById(int authorId)
        {
            AuthorViewModel author = this._service.GetOneAuthor(authorId);

            if (author != null)
            {
                try
                {
                    this._service.DeleteAuthor(authorId);
                }
                catch (Exception Ex)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public AuthorViewModel EditAuthor(AuthorViewModel inputAuthor)
        {
            AuthorViewModel author = this._service.GetOneAuthor(inputAuthor.Id);
            if (author != null)
            {
                try
                {
                    this._service.UpdateAuthor(inputAuthor);
                }
                catch (Exception Ex)
                {
                    return null;
                }

                return inputAuthor;
            }
            else
            {
                return null;
            }
        }


    }
}
