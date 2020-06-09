using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.SuperUser.DTOs
{
    public class UserDto
    {
        public Int64 pki_user_id { get; set; }
        public String vc_username { get; set; }
        public String vc_password { get; set; }
        public String vc_name { get; set; }
        public String vc_email { get; set; }
        public Boolean b_isreset { get; set; }
    }
}
