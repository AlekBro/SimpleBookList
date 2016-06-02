﻿namespace SimpleBookList.UI.Controllers
{
    using System;
    using System.Web.Mvc;

    using Models;

    public class MainController : Controller
    {
        /// <summary>
        /// Exception handling
        /// </summary>
        /// <param name="filterContext">Exception context</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;

            filterContext.ExceptionHandled = true;

            if (ex is ModelException)
            {
                ModelException bookException = ex as ModelException;

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

                tempDataDictionary.Add("errorMessage", "Error while processing your request!");

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