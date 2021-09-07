using System.Web;
using System.Web.Optimization;

namespace crssAssetDV
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        
                        "~/Scripts/jquery-{version}.js",
                        
                        "~/Scripts/DataTables/jquery.datatables.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
                        "~/Scripts/DataTables/searchBuilder.bootstrap4.min.js",
                        "~/Scripts/DataTables/dataTables.searchBuilder.min.js",


                        "~/Scripts/datatables.jqueryui.min.js",

                        "~/Scripts/DataTables/datatables.fixedHeader.min.js",
                        "~/Scripts/highcharts/7.1.2/highcharts.js",

                        "~/Scripts/dataTables.colReorder.min.js",
                        "~/Scripts/moment.min.js",

                        "~/Scripts/DataRender/datetime-moment.js",
                        "~/Scripts/DataRender/dateTime.js",

                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",

                        
                        
                        "~/Scripts/DataTables/dataTables.autoFill.min.js",
                        "~/Scripts/DataTables/autoFill.bootstrap4.min.js",
                       
                        "~/Scripts/DataTables/dataTables.responsive.min.js",
                        "~/Scripts/DataTables/responsive.bootstrap4.min.js",

                        "~/Scripts/DataTables/datatables.buttons.min.js",
                        "~/Scripts/DataTables/buttons.bootstratp4.min.js",
                        //"~/Scripts/DataTables/buttons.min.js",
 
                        "~/Scripts/jszip.min.js",
                        "~/Scripts/Pfdmake/pdfmake.min.js",
                        "~/Scripts/Pdfmake/vfs_fonts.js",
                        "~/Scripts/DataTables/buttons.html5.min.js",
                        "~/Scripts/DataTables/buttons.print.min.js",
                        "~/Scripts/DataTables/buttons.colVis.min.js"



                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



            bundles.Add(new StyleBundle("~/Content/css").Include(



                            "~/Content/bootstrap-theme.css",
                            "~/Content/DataTables/css/jqery.dataTables.min.css",
                            "~/Content/DataTables/css/dataTables.bootstrap4.min.css",
                            "~/Content/DataTables/css/autoFill.bootstrap4.min.css",
                            "~/Content/DataTables/css/buttons.dataTables.min.css",
                            //"~/Content/DataTables/css/buttons.bootstrap4.min.css",
                            "~/Content/DataTables/css/responsive.bootstrap4.min.css",
                            "~/Content/DataTables/css/searchBuilder.bootstrap4.min.css",

                            "~/Content/DataTables/css/colReorder.dataTables.min.css",

                            "~/Content/bootstrap-lumen.css",
                           
                            "~/Content/site.css"
                            
                      ));

        }
    }
}
