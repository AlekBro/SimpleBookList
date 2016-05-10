using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBookList.BLL.Interfaces;

namespace SimpleBookList.UI.Controllers
{
    using Models;

    public class AuthorsController : Controller
    {

        /// <summary>
        /// EventService class property
        /// </summary>
        private IBookListService Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController" /> class.
        /// </summary>
        /// <param name="service">implementation instance of IEventService interface</param>
        public AuthorsController(IBookListService service)
        {
            this.Service = service;
        }


        // GET: Authors
        public ActionResult Index()
        {
            return View(Service.GetAllAuthors());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {

            try
            {
                int authorId = Convert.ToInt32(id);
                AuthorViewModel currentAuthor = Service.GetOneAuthor(authorId);
                return View(currentAuthor);
            }
            catch (Exception ex)
            {

                throw;
            }


            return RedirectToAction("Index");
        }

        // GET: Authors/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Success!
                    Service.CreateAuthor(author);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(author);
                }
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AuthorViewModel author = null;

            author = this.Service.GetOneAuthor(id);

            if (author != null)
            {
                // Success!
                return this.View("Edit", author);
            }
            else
            {
                throw new Exception("Such author is not found in the database!");
            }
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Success!
                    this.Service.UpdateAuthor(author);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            AuthorViewModel author = null;

            author = this.Service.GetOneAuthor(id);
            if (author != null)
            {
                // Success!
                return this.View("Delete", author);
            }
            else
            {
                throw new Exception("Such author is not found in the database!");
            }
        }

        // POST: Authors/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuthor(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Success!
                    this.Service.DeleteAuthor(id);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                // ModelState.IsValid  False!
                throw new Exception();
            }
        }
    }
}
