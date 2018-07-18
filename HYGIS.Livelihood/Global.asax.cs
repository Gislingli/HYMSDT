using HYGIS.Livelihood.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HYGIS.Livelihood
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string filePath = Server.MapPath("~/Log/");
            ThreadPool.QueueUserWorkItem((a) => {
                while (true)
                {
                    //判断一下队列中是否有数据
                    if (MyExceptionAttribute.execptionQueue.Count > 0)
                    {
                        //出队
                        Exception ex = MyExceptionAttribute.execptionQueue.Dequeue();
                        if (ex != null)
                        {
                            //将异常信息写到日志文件中
                            string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                            File.AppendAllText(filePath + fileName + ".txt", ex.ToString(), System.Text.Encoding.UTF8);
                        }
                        else
                        {
                            //如果队列中没有数据，休息5秒钟
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        //如果队列中没有数据，休息
                        Thread.Sleep(3000);
                    }
                }
            });
        }
    }
}
