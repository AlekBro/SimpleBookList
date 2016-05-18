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


    public class MainController: Controller
    {
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