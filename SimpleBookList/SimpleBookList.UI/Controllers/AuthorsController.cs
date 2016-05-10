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
        public ActionResult Details(string id)
        {
            string[] idArray = id.Split('-');

            if (idArray.Count() != 0)
            {
                string idNumber = idArray[0];
                if (string.IsNullOrWhiteSpace(idNumber) == false)
                {
                    try
                    {
                        int authorId = Convert.ToInt32(idNumber);
                        AuthorViewModel currentAuthor = Service.GetOneAuthor(authorId);
                        return View(currentAuthor);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }
            }


            return RedirectToAction("Index");
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Authors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
