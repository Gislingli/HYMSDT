using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYGIS.Livelihood.Models
{
    public class Station
    {
        public System.Guid Sta_Guid { get; set; }
        public Nullable<int> Sta_Id { get; set; }
        public string Sta_Name { get; set; }
        public string Sta_Geo { get; set; }
    }


}