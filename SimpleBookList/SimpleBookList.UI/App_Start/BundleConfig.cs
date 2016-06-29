// -----------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.UI
{
    using System.Web.Optimization;

    /// <summary>
    /// Bundle Config
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        /// </summary>
        /// <param name="bundles">Bundle Collection</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include(
            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryValidate").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryMultiSelect").Include(
                        "~/Scripts/jquery.multi-select.js",
                        "~/Scripts/jquery.quicksearch.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryDatatables").Include(
                        "~/Scripts/jquery.dataTables*"));

            // Custom JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/forBooks").Include(
                        "~/Scripts/App/Books*"));

            // Custom JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/forAuthors").Include(
                        "~/Scripts/App/Authors*"));

            // Custom JavaScript for RequiredIfAttribute
            bundles.Add(new ScriptBundle("~/bundles/BooksValidation").Include(
                        "~/Scripts/App/Validation.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/*.css",
                      "~/Content/themes/base/*.css"));
        }
    }
}
