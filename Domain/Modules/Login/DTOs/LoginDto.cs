using AutoMapper;
using Database.Entities.Modules.Login;
using Database.Entities.Modules.Login.ViewModels;
using Domain.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.DTOs
{
    public class LoginDto : IMapFrom<UT_Admin_User>
    {
        public Int64 pki_user_id { get; set; }
        public String vc_username { get; set; }
        public String vc_password { get; set; }
        public String vc_name { get; set; }
        public String vc_email { get; set; }
        public Boolean b_isreset { get; set; }
        public Int32 b_timeout { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UT_Admin_User, LoginDto>()
                .ForMember(d => d.pki_user_id, opt => opt.MapFrom(s => s.pki_user_id))
                .ForMember(d => d.vc_username, opt => opt.MapFrom(s => s.vc_username))
                .ForMember(d => d.vc_password, opt => opt.MapFrom(s => s.vc_password))
                .ForMember(d => d.vc_name, opt => opt.MapFrom(s => s.vc_name))
                .ForMember(d => d.vc_email, opt => opt.MapFrom(s => s.vc_email))
                .ReverseMap();

            //profile.CreateMap<IList<LoginDto>, VM_UserRole>()
            //   .ForMember(desc => desc._UT_Admin_User , option => option.MapFrom(src => src));

            //profile.CreateMap<UT_Admin_User, LoginDto>().ReverseMap();
        }

    }
}
