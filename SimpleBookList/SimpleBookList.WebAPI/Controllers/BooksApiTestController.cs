using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBookList.Models;

namespace SimpleBookList.WebAPI.Controllers
{
    public class BooksApiTestController : Controller
    {
        // GET: BooksApiTest
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
            return this.PartialView("Create");
        }

        
        /// <summary>
        /// Get PartialView with Book for Edit
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>PartialView for Editing or Exception</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookViewModel bookForEdit = new BookViewModel();
            bookForEdit.Id = id;
            return this.PartialView("Edit", bookForEdit);
        }
        

    }
}