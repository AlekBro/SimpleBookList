﻿using System.Web;
using System.Web.Optimization;

namespace SimpleBookList.WebAPI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        /*
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
        */
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
            bundles.Add(new ScriptBundle("~/bundles/AppFunctions").Include(
                        "~/Scripts/App/App*"));

            // Custom JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/forBooks").Include(
                        "~/Scripts/App/Books*"));

            // Custom JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/forAuthors").Include(
                        "~/Scripts/App/Authors*"));

            // Custom JavaScript for set datepicker
            bundles.Add(new ScriptBundle("~/bundles/SetDatepicker").Include(
                        "~/Scripts/App/SetDatepicker.js"));

            // Custom JavaScript for working Cancel button
            bundles.Add(new ScriptBundle("~/bundles/CancelButton").Include(
                        "~/Scripts/App/CancelButton.js"));


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
