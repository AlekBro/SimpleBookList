namespace SimpleBookList.WebAPI.Controllers
{
    using System.Web.Mvc;

    using Models;

    public class ApiTestAuthorsController : Controller
    {
        // GET: ApiTestAuthors
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create new Author
        /// </summary>
        /// <returns>From for creating new Author</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView("Create");
        }

        /// <summary>
        /// Get PartialView with Author for Edit
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>PartialView for Editing or Exception</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AuthorViewModel author = new AuthorViewModel();
            author.Id = id;
            return this.PartialView("Edit", author);
        }

    }
}