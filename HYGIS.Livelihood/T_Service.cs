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
    
    public partial class T_Service
    {
        public System.Guid S_Guid { get; set; }
        public string S_Type { get; set; }
        public string S_Name { get; set; }
        public string S_Address { get; set; }
        public string S_QH { get; set; }
        public Nullable<double> S_Cost { get; set; }
        public Nullable<double> S_Star { get; set; }
        public System.Data.Entity.Spatial.DbGeometry S_Geo { get; set; }
        public string S_Introduce { get; set; }
        public Nullable<int> S_PhotoList { get; set; }
    }
}