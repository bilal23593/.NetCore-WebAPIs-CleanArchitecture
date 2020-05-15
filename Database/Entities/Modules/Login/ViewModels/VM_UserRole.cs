using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Entities.Modules.Login.ViewModels
{
    public class VM_UserRole    
    {
        public Int64 pki_user_id { get; set; }
        public Int64 pki_role_id { get; set; }
        public String vc_name { get; set; }
        public Boolean b_isreset { get; set; }
        public String vc_rolename { get; set; }
        public String vc_email { get; set; }
        public String vc_roledesc { get; set; }

    }
}
