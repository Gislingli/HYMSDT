//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HYGIS.Livelihood
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_LeisureTourism
    {
        public System.Guid LT_Guid { get; set; }
        public string LT_Type { get; set; }
        public string LT_Name { get; set; }
        public string LT_Address { get; set; }
        public string LT_QH { get; set; }
        public string LT_Grade { get; set; }
        public string LT_Time { get; set; }
        public System.Data.Entity.Spatial.DbGeometry LT_Geo { get; set; }
        public string LT_Introduce { get; set; }
        public Nullable<int> LT_PhotoList { get; set; }
    }
}
