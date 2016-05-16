namespace SimpleBookList.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using BLL.Interfaces;
    using Models;
    using Utils;

    /// <summary>
    /// Books Controller
    /// </summary>
    public class BooksController : Controller
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
                List<BookViewModel> allBooks = this.service.GetAllBooks().ToList();

                List<string> columnSearch = new List<string>();

                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                List<BookViewModel> data = new BookResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, allBooks, columnSearch);

                int count = new BookResultSet().Count(param.Search.Value, allBooks, columnSearch);

                DTResult<BookViewModel> result = new DTResult<BookViewModel>
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
        /// Create new Book
        /// </summary>
        /// <returns>From for creating new Book</returns>
        [HttpGet]
        public ActionResult Create()
        {
            MultiSelectList authorsList = new MultiSelectList(this.service.GetAllAuthors(), "Id", "Name");

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
                try
                {
                    // Success!
                    newBook = this.service.CreateBook(newBook);
                    return this.Json(newBook, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                // ModelState.IsValid  False!
                throw new CustomException(ViewData.ModelState);
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
            try
            {
                bookForEdit = this.service.GetOneBook(id);

                if (bookForEdit != null)
                {
                    List<string> authorsIds = bookForEdit.Authors.Select(x => x.Id.ToString()).ToList();
                    MultiSelectList authorsList = new MultiSelectList(this.service.GetAllAuthors(), "Id", "Name", authorsIds);
                    ViewBag.AuthorsList = authorsList;

                    // Success!
                    return this.PartialView("Edit", bookForEdit);
                }
                else
                {
                    throw new Exception("Such an Book is not found in the database!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                try
                {
                    // Success!
                    this.service.UpdateBook(bookForUpdate);
                    return this.Json(bookForUpdate, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                // ModelState.IsValid  False!
                throw new CustomException(ViewData.ModelState);
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
            try
            {
                bookForDelete = this.service.GetOneBook(id);
                if (bookForDelete != null)
                {
                    // Success!
                    return this.PartialView("Delete", bookForDelete);
                }
                else
                {
                    throw new Exception("Such an Book is not found in the database!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                try
                {
                    // Success!
                    this.service.DeleteBook(id);
                    return this.Json(id, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                // ModelState.IsValid  False!
                throw new CustomException(ViewData.ModelState);
            }
        }

        /// <summary>
        /// Exception handling
        /// </summary>
        /// <param name="filterContext">Exception context</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;

            filterContext.ExceptionHandled = true;

            if (ex is CustomException)
            {
                CustomException bookException = ex as CustomException;

                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = new JsonResult
                {
                    Data = new { error = filterContext.Exception.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                TempDataDictionary tempDataDictionary = new TempDataDictionary();

                if (string.IsNullOrWhiteSpace(ex.Message) == false)
                {
                    tempDataDictionary.Add("errorMessage", ex.Message);
                }
                else
                {
                    tempDataDictionary.Add("errorMessage", "Error while processing your request!");
                }

                ViewResult result = new ViewResult
                {
                    ViewName = "Error",
                    TempData = tempDataDictionary
                };

                filterContext.Result = result;
            }
        }
    }
}
