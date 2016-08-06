// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.UI.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : MainController
    {
        /// <summary>
        /// Main page
        /// </summary>
        /// <returns>>View with Main page for this Application</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Information about this Application
        /// </summary>
        /// <returns>View with Information about this Application</returns>
        public ActionResult About()
        {
            return this.View();
        }

        /// <summary>
        /// Contacts data
        /// </summary>
        /// <returns>View with Contacts data</returns>
        public ActionResult Contact()
        {
            return this.View();
        }

        public ActionResult Unauthorized()
        {
            return this.View();
        }
        

    }
}