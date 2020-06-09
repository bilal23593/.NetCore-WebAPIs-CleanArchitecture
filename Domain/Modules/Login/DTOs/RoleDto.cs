using AutoMapper;
using Database.Entities.Modules.Login;
using Domain.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.DTOs
{
    public class RoleDto 
    {
        public Int64 pki_role_id { get; set; }
        public String vc_rolename { get; set; }
        public String vc_roledesc { get; set; }
        public String vc_type { get; set; }
        public Int32 i_group { get; set; }
        public IList<MenuDTO> _MenuDto { get; set; }
    }
}
