using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace StudyBuddy
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/jquery-3.4.1.js",
                "~/Scripts/umd/popper.js",
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Style/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
