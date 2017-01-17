using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBookList.SPA.Controllers
{
    public class AngularBooksController : Controller
    {
        // GET: AngularBooks
        public ActionResult Index()
        {
            return View();
        }
    }
}