using System.Web.Optimization;

namespace GlobeFA.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                           "~/Scripts/jquery-{version}.js",
                           "~/Scripts/jquery-1.11.0.js",
                           "~/Scripts/plugins/metisMenu/metisMenu.min.js",
                           "~/Scripts/sb-admin-2.js",
                           "~/Scripts/angular.treeview.js"
                           ));

            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                       "~/Scripts/angular.min.js"
                       ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/bootstrap-overrides.css",
                      "~/Content/plugins/metisMenu/metisMenu.min.css",
                      "~/Content/plugins/timeline.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/plugins/morris.css",
                      "~/fonts/font-awesome-4.1.0/css/font-awesome.min.css",
                      "~/Content/site.css",
                      "~/Content/angular.treeview.css"
                      ));
        }
    }
}
