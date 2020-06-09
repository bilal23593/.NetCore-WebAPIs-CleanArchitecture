using Domain.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.DTOs
{
    public class MenuDTO
    {

        public Int64 pki_menu_id { get; set; }
        public Int64 fki_parent_id { get; set; }
        public String vc_menu { get; set; }
        public String vc_menu_controller { get; set; }
        public String vc_menu_action { get; set; }
       // public String vc_menu_link { get; set; }
        public String vc_menu_icon { get; set; }
        //public Int64 bi_createdby { get; set; }
        //public DateTime dt_createdon { get; set; }
        //public Int64 bi_modifiedby { get; set; }
        //public DateTime dt_modifiedon { get; set; }
        //public Boolean b_isdeleted { get; set; }
        ///public String ExcluType { get; set; }


    }
}
