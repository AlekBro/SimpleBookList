namespace SimpleBookList.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using BLL.Interfaces;
    using Models;
    using Utils;

    /// <summary>
    /// Authors Controller
    /// </summary>
    public class AuthorsController : Controller
    {
        /// <summary>
        /// EventService class property
        /// </summary>
        private IBookListService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController" /> class.
        /// </summary>
        /// <param name="service">implementation instance of IEventService interface</param>
        public AuthorsController(IBookListService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get List with all Authors
        /// </summary>
        /// <returns>List with all Authors</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Get JSON with Author List
        /// </summary>
        /// <param name="param">sorting and searching parameters</param>
        /// <returns>JSON with Author List</returns>
        public JsonResult DataHandler(DTParameters param)
        {
            try
            {
                List<AuthorViewModel> allAuthors = this.service.GetAllAuthors().ToList();

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
                return this.Json(result);
            }
            catch (Exception ex)
            {
                return this.Json(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get Author details
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>Form with Author details</returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                int authorId = Convert.ToInt32(id);
                AuthorViewModel currentAuthor = this.service.GetOneAuthor(authorId);
                return this.View(currentAuthor);
            }
            catch (Exception ex)
            {
                throw;
            }

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <returns>Form for creating</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <param name="author">Author View Model</param>
        /// <returns>Creating result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Success!
                    this.service.CreateAuthor(author);
                    return this.RedirectToAction("Index");
                }
                catch
                {
                    return this.View(author);
                }
            }

            return this.View(author);
        }

        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>Form for updating</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AuthorViewModel author = null;

            author = this.service.GetOneAuthor(id);

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

        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="author">Author View Model</param>
        /// <returns>Updating result</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Success!
                    this.service.UpdateAuthor(author);
                    return this.RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return this.View(author);
        }

        /// <summary>
        /// Delete Author by Id
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>Form for deleting</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            AuthorViewModel author = null;

            author = this.service.GetOneAuthor(id);
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

        /// <summary>
        /// Author deleting by his Id
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns></returns>
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
                    this.service.DeleteAuthor(id);
                    return this.RedirectToAction("Index");
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
