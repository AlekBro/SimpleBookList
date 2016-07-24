
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

    public class DataTableController : ApiController
    {
        /// <summary>
        /// BookService class property
        /// </summary>
        private IBookListService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTableController" /> class.
        /// </summary>
        /// <param name="service">implementation instance of IBookService interface</param>
        public DataTableController(IBookListService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Get JSON with Book List
        /// </summary>
        /// <param name="param">searching and filtering parameters</param>
        /// <returns>JSON with Book List</returns>
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post([FromBody]DTParameters param)
        {
            List<BookViewModel> allBooks = this.service.GetAllBooks().ToList();

            List<string> columnSearch = new List<string>();
            List<BookViewModel> data = null;
            int count = 0;
            int draw = 10;
            if (param != null && param.Columns != null)
            {
                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                data = new BookResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, allBooks, columnSearch);
                count = new BookResultSet().Count(param.Search.Value, allBooks, columnSearch);
                draw = param.Draw;
            }
            else
            {
                data = allBooks;
                count = data.Count();
            }

            DTResult<BookViewModel> result = new DTResult<BookViewModel>
            {
                draw = draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
