using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApp.App_Start
{
    public class BundlesConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            //Scripts 
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/modernizr-2.6.2.js"));

            //Styles
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}