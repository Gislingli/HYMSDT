using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYGIS.Livelihood.Models
{
    public class LeisureTourism
    {
        public System.Guid LT_Guid { get; set; }
        public string LT_Type { get; set; }
        public string LT_Name { get; set; }
        public string LT_Address { get; set; }
        public string LT_QH { get; set; }
        public string LT_Grade { get; set; }
        public string LT_Time { get; set; }
        public string LT_Geo { get; set; }
        public string LT_Introduce { get; set; }
        public Nullable<int> LT_PhotoList { get; set; }
    }
}