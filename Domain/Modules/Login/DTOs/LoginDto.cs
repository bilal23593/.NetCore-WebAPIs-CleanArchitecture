﻿using AutoMapper;
using Database.Entities.Modules.Login;
using Database.Entities.Modules.Login.ViewModels;
using Domain.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.DTOs
{
    public class LoginDto 
    {
        public Int64 pki_user_id { get; set; }
        public String vc_username { get; set; }
        public String vc_password { get; set; }
        public String vc_name { get; set; }
        public String vc_email { get; set; }
        public Boolean b_isreset { get; set; }
        public Int32 b_timeout { get; set; }
        public IList<RoleDto> _RoleDto { get; set; }

    }
}
