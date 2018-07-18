using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYGIS.Livelihood.Models
{
    public class ReturnModel1
    {
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class ReturnModel2
    {
        public string ErrorMessage = null;

        public ReturnModel2() { }
        public ReturnModel2(string err)
        {
            this.ErrorMessage = err;
        }

        private Dictionary<string, object> _Data = new Dictionary<string, object>();
        public Dictionary<string, object> Data
        {
            get { return this._Data; }
            set { this._Data = value; }
        }

        public void Add(string key, object value)
        {
            this._Data[key] = value;
        }
    }

    public class ReturnModel3
    {
        public int status { get; set; }
        public string ErrorMessage { get; set; }
    }
}