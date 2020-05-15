using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities.Modules
{
    public class ModelBase
    {
        public Int64 bi_createdby { get; set; }
        public DateTime dt_createdon { get; set; }
        public Int64 bi_modifiedby { get; set; }
        public DateTime dt_modifiedon { get; set; }
        public Boolean b_isdeleted { get; set; }
    }
}
