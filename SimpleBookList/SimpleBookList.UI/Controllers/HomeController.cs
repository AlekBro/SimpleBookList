namespace SimpleBookList.UI.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
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
    }
}