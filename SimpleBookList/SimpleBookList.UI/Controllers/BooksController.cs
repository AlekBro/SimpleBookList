﻿namespace SimpleBookList.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using BLL.Interfaces;
    using SimpleBookList.Models;
    using Utils;

    public class BooksController : Controller
    {


        /// <summary>
        /// EventService class property
        /// </summary>
        private IBookListService Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController" /> class.
        /// </summary>
        /// <param name="service">implementation instance of IEventService interface</param>
        public BooksController(IBookListService service)
        {
            this.Service = service;
        }




        // GET: Books
        public ActionResult Index()
        {
            //IEnumerable<BookViewModel> allBooks = this.Service.GetAllBooks();
            //return View(allBooks);
            return View();
        }

        [HttpPost]
        public JsonResult LoadData()
        {

            //Get parameters

            // get Start (paging start index) and length (page size for paging)
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            //Get Sort columns value
            var r1 = Request.Form.GetValues("order[0][column]").FirstOrDefault();

            //columns[0][name]
            // col = "columns[1][name]"
            string col = "columns[" + r1 + "][name]";

            // [8] = "columns[1][name]"
            var sortColumn = Request.Form.GetValues(col).FirstOrDefault();



            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            //var res = Request.Form.AllKeys.GetValue()

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;


            IEnumerable<BookViewModel> allBooks = this.Service.GetAllBooks();

            var v = (from a in allBooks select a);

            //Sorting
            /*
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                v = v.OrderBy(sortColumn + " " + sortColumnDir);
            }
            */

            totalRecords = v.Count();
            var data = v.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = data }, JsonRequestBehavior.AllowGet);


            //return View(allBooks);
        }




        //---------------------------------------------------------------------------------

   
    

        
    public JsonResult DataHandler(DTParameters param)
    {
        try
        {

            List<BookViewModel> allBooks = this.Service.GetAllBooks().ToList();

            List<string> columnSearch = new List<string>();

            foreach (var col in param.Columns)
            {
                columnSearch.Add(col.Search.Value);
            }

            List<BookViewModel> data = new ResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, allBooks, columnSearch);

            int count = new ResultSet().Count(param.Search.Value, allBooks, columnSearch);

            DTResult<BookViewModel> result = new DTResult<BookViewModel>
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


        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Books/Edit/5
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

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
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
