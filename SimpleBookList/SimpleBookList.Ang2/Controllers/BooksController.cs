// -----------------------------------------------------------------------
// <copyright file="BooksController.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Ang2.Controllers
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
    using Models.Utils;

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
        /// Get JSON with Book List
        /// </summary>
        /// <param name="param">searching and filtering parameters</param>
        /// <returns>JSON with Book List</returns>
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get([FromUri]DTParameters param)
        {
            List<string> columnSearch = new List<string>();
            List<BookViewModel> data = null;
            int count = 0;
            int draw = 10;
            if (param != null && param.Columns != null)
            {
                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                data = new BookResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, this.service.GetAllBooks(), columnSearch);
                count = new BookResultSet().Count(param.Search.Value, this.service.GetAllBooks(), columnSearch);
                draw = param.Draw;
            }
            else
            {
                data = this.service.GetAllBooks().ToList();
                count = data.Count();
            }

            DTResult<BookViewModel> result = new DTResult<BookViewModel>
            {
                draw = draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
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
        [System.Web.Http.HttpPost]
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
        /// <param name="value">Edited Book in BookViewModel</param>
        /// <returns></returns>
        //[System.Web.Http.HttpPut]
        public HttpResponseMessage Put(int id, BookViewModel value)
        {
            BookViewModel book = this.service.GetOneBook(id);
            if (book == null)
            {
                var message = string.Format("Book with id = {0} not found", id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }

            if (value != null && ModelState.IsValid)
            {
                // Success!
                this.service.UpdateBook(value);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                // ModelState.IsValid  False!
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete one Book by his Id
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Ok or Error response</returns>
        [System.Web.Http.HttpDelete]
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
