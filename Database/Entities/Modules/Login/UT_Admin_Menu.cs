using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities.Modules.Login
{
    public class UT_Admin_Menu : ModelBase
    {
        [Key]
        public Int64 pki_menu_id { get; set; }
        public Int64 fki_parent_id { get; set; }
        public String vc_menu { get; set; }
        public String vc_menu_controller { get; set; }
        public String vc_menu_action { get; set; }
        public String vc_menu_link { get; set; }
        public String vc_menu_icon { get; set; }
    }
}
