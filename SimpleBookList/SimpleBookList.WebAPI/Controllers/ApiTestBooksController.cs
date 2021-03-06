﻿namespace SimpleBookList.WebAPI.Controllers
{
    using System.Web.Mvc;

    using Models;

    public class ApiTestBooksController : Controller
    {
        // GET: ApiTest
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create new Book
        /// </summary>
        /// <returns>From for creating new Book</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        /// <summary>
        /// Get PartialView with Book for Edit
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>PartialView for Editing or Exception</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookViewModel book = new BookViewModel();
            book.Id = id;
            return this.PartialView(book);
        }
    }
}