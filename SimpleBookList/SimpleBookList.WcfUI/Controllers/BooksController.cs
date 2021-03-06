﻿// -----------------------------------------------------------------------
// <copyright file="BooksController.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.WcfUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models;    //using Models;
    using Models.DataTableModels;
    using SimpleBookList.WcfUI.BooksListServiceReference;
    using Models.Utils;
    /// <summary>
    /// Books Controller
    /// </summary>
    public class BooksController : Controller
    {

        private ServiceClient serviceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController" /> class.
        /// </summary>
        public BooksController()
        {
            this.serviceClient = new ServiceClient();
        }

        /// <summary>
        /// Get main page with Book List
        /// </summary>
        /// <returns>Book List</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Get JSON with Book List
        /// </summary>
        /// <param name="param">searching and filtering parameters</param>
        /// <returns>JSON with Book List</returns>
        public JsonResult DataHandler(DTParameters param)
        {
            try
            {
                /*
                List<string> columnSearch = new List<string>();

                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                List<BookViewModel> data = new BookResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, this.serviceClient.GetBookList(), columnSearch);

                int count = new BookResultSet().Count(param.Search.Value, this.serviceClient.GetBookList(), columnSearch);

                DTResult<BookViewModel> result = new DTResult<BookViewModel>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = count,
                    recordsTotal = count
                };
                */

                DTResult<BookViewModel> result = this.serviceClient.GetBooks(param);

                return this.Json(result);
            }
            catch (Exception ex)
            {
                return this.Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Create new Book
        /// </summary>
        /// <returns>From for creating new Book</returns>
        [HttpGet]
        public ActionResult Create()
        {
            MultiSelectList authorsList = new MultiSelectList(this.serviceClient.GetAuthorList().ToList(), "Id", "Name");

            ViewBag.AuthorsList = authorsList;

            return this.PartialView("Create");
        }

        /// <summary>
        /// Post new BookModel for saving in Database
        /// </summary>
        /// <param name="newBook">BookModel with new Book</param>
        /// <returns>BookModel or Exception</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel newBook)
        {
            if (ModelState.IsValid)
            {
                Nullable<int> newBookId = this.serviceClient.AddNewBook(newBook);
                if (newBookId.HasValue)
                {
                    // Success!
                    BookViewModel newBookFromDB = this.serviceClient.GetBookById(newBookId.Value);
                    return this.Json(newBookFromDB, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("Something went wrong while adding new book!");
                }
            }
            else
            {
                // ModelState.IsValid  False!
                throw new ModelException(ViewData.ModelState);
            }
        }

        /// <summary>
        /// Get PartialView with Book for Edit
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>PartialView for Editing or Exception</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookViewModel bookForEdit = null;
            bookForEdit = this.serviceClient.GetBookById(id);

            if (bookForEdit != null)
            {
                List<string> authorsIds = bookForEdit.Authors.Select(x => x.Id.ToString()).ToList();
                MultiSelectList authorsList = new MultiSelectList(this.serviceClient.GetAuthorList(), "Id", "Name", authorsIds);
                ViewBag.AuthorsList = authorsList;

                // Success!
                return this.PartialView("Edit", bookForEdit);
            }
            else
            {
                throw new ArgumentException("Such Book is not found in the database!");
            }
        }

        /// <summary>
        /// Post BookModel with updated data for saving in database
        /// </summary>
        /// <param name="bookForUpdate">updated BookModel</param>
        /// <returns>BookModel or Exception</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel bookForUpdate)
        {
            if (ModelState.IsValid)
            {
                // Success!
                this.serviceClient.EditBook(bookForUpdate);
                return this.Json(bookForUpdate, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // ModelState.IsValid  False!
                throw new ModelException(ViewData.ModelState);
            }
        }

        /// <summary>
        /// Get PartialView with Book for Delete
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>PartialView for Deleting or Exception</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BookViewModel bookForDelete = null;
            bookForDelete = this.serviceClient.GetBookById(id);
            if (bookForDelete != null)
            {
                // Success!
                return this.PartialView("Delete", bookForDelete);
            }
            else
            {
                throw new ArgumentException("Such Book is not found in the database!");
            }
        }

        /// <summary>
        /// Post Book id and deleting Book by Id
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>BookModel or Exception</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook(int id)
        {
            if (ModelState.IsValid)
            {
                // Success!
                this.serviceClient.DeleteBookById(id);
                return this.Json(id, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // ModelState.IsValid  False!
                throw new ModelException(ViewData.ModelState);
            }
        }


    }
}
