﻿using HYGIS.Livelihood.Attributes;
using System.Web;
using System.Web.Mvc;

namespace HYGIS.Livelihood
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionAttribute());
        }
    }
}
