namespace SimpleBookList.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Models;
    using BLL.Interfaces;
    using Utils;

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
        [HttpGet]
        public ActionResult Index()
        {
            //return View(Service.GetAllAuthors());
            return View();
        }




        //---------------------------------------------------------------------------------



        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public JsonResult DataHandler(DTParameters param)
        {
            try
            {

                List<AuthorViewModel> allAuthors = this.Service.GetAllAuthors().ToList();

                List<string> columnSearch = new List<string>();

                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                List<AuthorViewModel> data = new AuthorResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, allAuthors, columnSearch);

                int count = new AuthorResultSet().Count(param.Search.Value, allAuthors, columnSearch);

                DTResult<AuthorViewModel> result = new DTResult<AuthorViewModel>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = count,
                    recordsTotal = count
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        //-------------------------------------------------------------------------





        // GET: Authors/Details/5
        [HttpGet]
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
