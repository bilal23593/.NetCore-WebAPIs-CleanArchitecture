using AutoMapper;
using Database.Entities.Modules.Login.ViewModels;
using Domain.Modules.Login.DTOs;
using Domain.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.ViewModels
{
    public class VM_UserRoleDto : IMapFrom<VM_UserRole>
    {
        public LoginDto _LoginDto { get; set; }

        public RoleDto _RoleDto { get; set; }

        public void Mapping(Profile profile)
        {

            //profile.CreateMap<IList<LoginDto>, VM_UserRole>()
            //   .ForMember(desc => desc._UT_Admin_User , option => option.MapFrom(src => src));

            profile.CreateMap<VM_UserRole, VM_UserRoleDto>()
                .ForMember(des => des._LoginDto.pki_user_id, option => option.MapFrom(src => src.pki_user_id))
                .ForMember(des => des._RoleDto.pki_role_id, option => option.MapFrom(src => src.pki_role_id))
                .ForMember(des => des._LoginDto.vc_name, option => option.MapFrom(src => src.vc_name))
                .ForMember(des => des._LoginDto.b_isreset, option => option.MapFrom(src => src.b_isreset))
                .ForMember(des => des._RoleDto.vc_rolename, option => option.MapFrom(src => src.vc_rolename))
                .ForMember(des => des._LoginDto.vc_email, option => option.MapFrom(src => src.vc_email))
                .ForMember(des => des._RoleDto.vc_roledesc, option => option.MapFrom(src => src.vc_roledesc))
                .ReverseMap();

    }
    }
}
