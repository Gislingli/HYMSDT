using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYGIS.Livelihood.Models
{
    public class BusStation
    {
        public System.Guid Sta_Guid { get; set; }
        public string Sta_Name { get; set; }
        public string Sta_Geo { get; set; }
        public string BL_Name { get; set; }
        public System.Guid BL_S_Guid { get; set; }
        public string BL_UpStartTime { get; set; }
        public string BL_UpEndTime { get; set; }
        public string BL_DownStartTime { get; set; }
        public string BL_DownEndTime { get; set; }
        public string BL_Geo { get; set; }
    }
}