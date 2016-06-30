// -----------------------------------------------------------------------
// <copyright file="BooksController.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;

    using BLL.Interfaces;
    using Models;
    using Models.DataTableModels;
    using Utils;

    /// <summary>
    /// Books Controller
    /// </summary>
    public class BooksController : ApiController
    {
        /// <summary>
        /// BookService class property
        /// </summary>
        private IBookListService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController" /> class.
        /// </summary>
        /// <param name="service">implementation instance of IBookService interface</param>
        public BooksController(IBookListService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get all Books in List
        /// </summary>
        /// <returns>BookViewModel list</returns>
        public IEnumerable<BookViewModel> Get()
        {
            return this.service.GetAllBooks().ToList();
        }

        /// <summary>
        /// Get one Book by his Id
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>BookViewModel</returns>
        public HttpResponseMessage Get(int id)
        {
            BookViewModel book = this.service.GetOneBook(id);

            if (book == null)
            {
                var message = string.Format("Book with id = {0} not found", id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, book);
            //return book;
        }

        /// <summary>
        /// Create new Book and add to Database
        /// </summary>
        /// <param name="value">BookViewModel</param>
        /// <returns>new Book in BookViewModel</returns>
        public HttpResponseMessage Post([FromBody]BookViewModel value)
        {
            if (ModelState.IsValid)
            {
                // Success!
                value = this.service.CreateBook(value);
                return Request.CreateResponse(HttpStatusCode.OK, value);
            }
            else
            {
                // ModelState.IsValid  False!
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        /// <summary>
        /// Edit Book
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <param name="value">Edited Book in BookViewModel</param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, [FromBody]BookViewModel value)
        {
            if (ModelState.IsValid)
            {
                // Success!
                this.service.UpdateBook(value);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                // ModelState.IsValid  False!
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        /// <summary>
        /// Delete one Book by his Id
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Ok or Error response</returns>
        public HttpResponseMessage Delete(int id)
        {
            BookViewModel bookForDelete = null;
            bookForDelete = this.service.GetOneBook(id);
            if (bookForDelete != null)
            {
                // Success!
                this.service.DeleteBook(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                var message = string.Format("Book with id = {0} not found", id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
    }
}
