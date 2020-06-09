using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities.Modules.Login
{
    public class UT_Admin_User : ModelBase
    {
        [Key]
        public Int64 pki_user_id { get; set; }
        public String vc_username { get; set; }
        public String vc_password { get; set; }
        public String vc_name { get; set; }
        public String vc_email { get; set; }
        public Boolean b_isreset { get; set; }

        public IList<UT_Admin_Role> _UT_Admin_Role { get; set; }

    }
}
