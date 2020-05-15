using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities.Modules.Login
{
    public class UT_Admin_Role : ModelBase
    {
        [Key]
        public Int64 pki_role_id { get; set; }
        public String vc_rolename { get; set; }
        public String vc_roledesc { get; set; }
        public String vc_type { get; set; }
        public Int32 i_group { get; set; }
        
        
    }
}
