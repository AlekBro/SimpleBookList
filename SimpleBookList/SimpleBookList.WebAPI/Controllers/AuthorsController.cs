
namespace SimpleBookList.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;

    using BLL.Interfaces;
    using Models;
    using Models.DataTableModels;
    using Utils;


    public class AuthorsController : ApiController
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
        /// Get JSON with Author List
        /// </summary>
        /// <param name="param">searching and filtering parameters</param>
        /// <returns>JSON with Author List</returns>
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Get([FromUri]DTParameters param)
        {
            var request = Request;

            List<AuthorViewModel> allAuthors = this.service.GetAllAuthors().ToList();

            List<string> columnSearch = new List<string>();
            List<AuthorViewModel> data = null;
            int count = 0;
            int draw = 10;
            if (param != null && param.Columns != null)
            {
                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                data = new AuthorResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, allAuthors, columnSearch);
                count = new AuthorResultSet().Count(param.Search.Value, allAuthors, columnSearch);
                draw = param.Draw;
            }
            else
            {
                data = allAuthors;
                count = data.Count();
            }

            DTResult<AuthorViewModel> result = new DTResult<AuthorViewModel>
            {
                draw = draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Get one Author by his Id
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>AuthorViewModel</returns>
        public HttpResponseMessage Get(int id)
        {
            AuthorViewModel author = this.service.GetOneAuthor(id);

            if (author == null)
            {
                var message = string.Format("Author with id = {0} not found", id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, author);
        }

        /// <summary>
        /// Create new Author and add to Database
        /// </summary>
        /// <param name="value">AuthorViewModel</param>
        /// <returns>new Author in AuthorViewModel</returns>
        public HttpResponseMessage Post([FromBody]AuthorViewModel value)
        {
            if (ModelState.IsValid)
            {
                // Success!
                value = this.service.CreateAuthor(value);
                return Request.CreateResponse(HttpStatusCode.OK, value);
            }
            else
            {
                // ModelState.IsValid  False!
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        /// <summary>
        /// Edit Author
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <param name="value">Edited Author in AuthorViewModel</param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, [FromBody]AuthorViewModel value)
        {
            if (ModelState.IsValid)
            {
                // Success!
                this.service.UpdateAuthor(value);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                // ModelState.IsValid  False!
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        /// <summary>
        /// Delete one Author by his Id
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>Ok or Error response</returns>
        public HttpResponseMessage Delete(int id)
        {
            AuthorViewModel authorForDelete = null;
            authorForDelete = this.service.GetOneAuthor(id);
            if (authorForDelete != null)
            {
                // Success!
                this.service.DeleteAuthor(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                var message = string.Format("Author with id = {0} not found", id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }

    }
}
