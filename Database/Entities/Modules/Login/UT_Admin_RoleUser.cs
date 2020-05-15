using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities.Modules.Login
{
    public class UT_Admin_RoleUser : ModelBase
    {
        [Key]
        public Int64 pki_roleuser_id { get; set; }
        public Int64 fki_role_id { get; set; }
        public Int64 fki_user_id { get; set; }
        
    }
}
