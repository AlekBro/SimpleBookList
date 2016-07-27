namespace SimpleBookList.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;


    using Models;
    using Models.DataTableModels;
    using Models.Utils;
    using WcfUI.BooksListServiceReference;
    /// <summary>
    /// Authors Controller
    /// </summary>
    public class AuthorsController : Controller
    {
        private ServiceClient serviceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController" /> class.
        /// </summary>
        public AuthorsController()
        {
            this.serviceClient = new ServiceClient();
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
                /*
                List<string> columnSearch = new List<string>();

                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                List<AuthorViewModel> data = new AuthorResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, this.serviceClient.GetAuthorList(), columnSearch);

                int count = new AuthorResultSet().Count(param.Search.Value, this.serviceClient.GetAuthorList(), columnSearch);

                DTResult<AuthorViewModel> result = new DTResult<AuthorViewModel>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = count,
                    recordsTotal = count
                };
                */
                DTResult<AuthorViewModel> result = this.serviceClient.GetAuthors(param);

                return this.Json(result);
            }
            catch (Exception)
            {
                return this.Json(new { error = "Error while processing your request!" });
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
            AuthorViewModel currentAuthor = this.serviceClient.GetAuthorById(id);
            return this.View(currentAuthor);
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
                // Success!
                this.serviceClient.AddNewAuthor(author);
                return this.RedirectToAction("Index");
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

            author = this.serviceClient.GetAuthorById(id);

            if (author != null)
            {
                // Success!
                return this.View("Edit", author);
            }
            else
            {
                throw new ArgumentException("The author with such Id does not exist!");
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
                // Success!
                this.serviceClient.EditAuthor(author);
                return this.RedirectToAction("Index");
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

            author = this.serviceClient.GetAuthorById(id);
            if (author != null)
            {
                // Success!
                return this.View("Delete", author);
            }
            else
            {
                throw new ArgumentException("The author with such Id does not exist!");
            }
        }

        /// <summary>
        /// Author deleting by his Id
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>Form for Author deleting</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuthor(int id)
        {
            if (ModelState.IsValid)
            {
                // Success!
                this.serviceClient.DeleteAuthorById(id);
                return this.RedirectToAction("Index");
            }
            else
            {
                // ModelState.IsValid  False!
                throw new ArgumentException("The author with such Id does not exist!");
            }
        }
    }
}
