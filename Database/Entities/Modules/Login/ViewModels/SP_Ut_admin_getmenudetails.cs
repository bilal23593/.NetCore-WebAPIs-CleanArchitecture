using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities.Modules.Login.ViewModels
{
    public class SP_Ut_admin_getmenudetails
    {
            public Int64 pki_role_id { get; set; }
            public Int64 pki_menu_id { get; set; }
            public Int64 fki_parent_id { get; set; }
            public String vc_menu { get; set; }
            public String vc_menu_controller { get; set; }
            public String vc_menu_action { get; set; }
           // public String vc_menu_link { get; set; }  
            public String vc_menu_icon { get; set; }
           // public long vc_exclutype { get; set; }
    }
}
