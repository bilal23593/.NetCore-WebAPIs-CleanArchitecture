using AutoMapper;
using Database.Entities.Modules.Login.ViewModels;
using Domain.Modules.Login.DTOs;
using Domain.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using Database.Entities.Modules.Login;
using System.Linq;

namespace Domain.Modules.Login.ViewModels
{
    public class VM_UserRoleDto //: IMapFrom<SP_Ut_admin_getuserdetails>
    {
        public IList<LoginDto> _LoginDto { get; set; }
        public IList<RoleDto> _RoleDto { get; set; }
      
    }
}
