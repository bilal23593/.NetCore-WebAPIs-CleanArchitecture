using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities.Modules
{
    public class ModelBase
    {
        public ModelBase(){
            bi_createdby = 0;
            dt_createdon = DateTime.Now;
            bi_modifiedby = 0;
        dt_modifiedon = DateTime.Now;
            b_isdeleted = false;
        }
        public Int64 bi_createdby { get; set; }
        public DateTime dt_createdon { get; set; }
        public Int64 bi_modifiedby { get; set; }
        public DateTime dt_modifiedon { get; set; }
        public Boolean b_isdeleted { get; set; }
    }
}
