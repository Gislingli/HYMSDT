using System.IO;
using System.Web;
using System.Web.Optimization;

namespace HYGIS.Livelihood
{
    public class BundleConfig
    {
        private static string _refPath = "~/Refers/";
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var cssPattern = "*.css";
            var lessPattern = "*.less";
            var jsPattern = "*.js";
            var jsxPattern = "*.jsx";
            bundles.Add(new ScriptBundle("~/Core").Include(
                _refPath + "jquery.min.js",
                _refPath + "react-15.6.2/react.min.js",
                _refPath + "react-15.6.2/react-with-addons.min.js",
                _refPath + "react-15.6.2/react-dom.min.js"
                ));
            //AntdJS
            bundles.Add(new ScriptBundle("~/AntdJS").Include(
                _refPath + "moment.js",
                _refPath + "antd3.4.1/antd.min.js"
                ));
            //AntdCSS
            bundles.Add(new LessBundle("~/AntdCSS").Include(
                _refPath + "antd3.4.1/antd.min.css"
                ));
            //AntdMobileJS
            bundles.Add(new ScriptBundle("~/AntdMobileJS").Include(
                _refPath + "moment.js",
                _refPath + "andt_mobile2.2.1/antd-mobile.min.js"
                ));
            //AntdMobileCSS
            bundles.Add(new LessBundle("~/AntdMobileCSS").Include(
                _refPath + "andt_mobile2.2.1/antd-mobile.min.css"
                ));
            //leaflet&MapPlugins
            bundles.Add(new ScriptBundle("~/Leaflet").Include(
                _refPath + "leaflet/leaflet-src.js",
                _refPath + "MapPlugins/__leafletExtends__.js"
                ));
            //icon
            bundles.Add(new LessBundle("~/Icon").Include(
                _refPath + "iconfont/iconfont.css",
                _refPath + "leaflet/leaflet.css"
                ));

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Components");
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                var fileName = dir.Name;
                // js打包
                bundles.Add(new Bundle(string.Format("~/{0}/js", fileName))
                            .IncludeDirectory("~/Components/" + fileName, jsPattern, true)
                            .IncludeDirectory("~/Components/" + fileName, jsxPattern, true));

                // 样式打包
                bundles.Add(new LessBundle(string.Format("~/{0}/css", fileName))
                    .IncludeDirectory("~/Components/" + fileName, cssPattern, true)
                    .IncludeDirectory("~/Components/" + fileName, lessPattern, true));
            }
        }
    }
}
