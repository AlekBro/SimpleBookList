﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SimpleBookList.BLL.Interfaces;
using SimpleBookList.Models;

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
    }
}