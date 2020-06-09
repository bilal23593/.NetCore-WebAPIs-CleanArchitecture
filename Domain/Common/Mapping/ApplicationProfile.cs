using AutoMapper;
using Data.Util;
using Database.Entities.Modules.Login;
using Database.Entities.Modules.Login.ViewModels;
using Domain.Modules.Login.DTOs;
using Domain.Modules.Login.ViewModels;
using Domain.Modules.SuperUser.DTOs;
using Domain.Modules.SuperUser.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Domain.Common.Mapping
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            IMapper new1 = null;

            CreateMap<UT_Admin_User, UserDto>().ReverseMap();
            CreateMap<IList<UT_Admin_User>, UserDtoList>()
                .ForMember(desc => desc.userDtoList, option => option.MapFrom(src => src));

            CreateMap<LoginDto, UT_Admin_User>().ReverseMap();

            CreateMap<RoleDto, LoginDto>();
            CreateMap<IList<RoleDto>, LoginDto>()
                 .ForMember(des => des._RoleDto, option => option.MapFrom(src => src.Select(x => new RoleDto
                 {
                     pki_role_id = x.pki_role_id,
                     vc_rolename = x.vc_rolename,
                     vc_roledesc = x.vc_roledesc
                 })));

            CreateMap<SP_Ut_admin_getuserdetails, LoginDto>().ReverseMap();

            CreateMap<IList<SP_Ut_admin_getuserdetails>, LoginDto>()
                .ForMember(des => des.pki_user_id, opt => opt.MapFrom(src => src[0].pki_user_id))
                .ForMember(des => des.vc_name, opt => opt.MapFrom(src => src[0].vc_name))
                .ForMember(des => des.vc_email, opt => opt.MapFrom(src => src[0].vc_email))
                .ForMember(des => des.b_isreset, opt => opt.MapFrom(src => src[0].b_isreset))
                .ForMember(des => des._RoleDto, option => option.MapFrom(src => src.Select(x => new RoleDto
                {
                    pki_role_id = x.pki_role_id,
                    vc_rolename = x.vc_rolename,
                    vc_roledesc = x.vc_roledesc
                })));


            //CreateMap<IList<SP_Ut_admin_getmenudetails>, LoginDto>()
            //    .ForMember(des => des._RoleDto, option => option.MapFrom(src => src.Select(x => new RoleDto
            //    {
            //    })));
            CreateMap<IList<SP_Ut_admin_getmenudetails>, LoginDto>()
                .ForMember(des => des.pki_user_id, opt => opt.Ignore())
                .ForMember(des => des._RoleDto, option => option
                            .MapFrom(
                                src => new1.Map<IList<SP_Ut_admin_getmenudetails>, IList<RoleDto>>(src.ToList())
                                    .Select(x => new RoleDto {
                                        pki_role_id = x.pki_role_id
                                    }))
                );

            CreateMap<SP_Ut_admin_getmenudetails, MenuDTO>();

            CreateMap<SP_Ut_admin_getmenudetails,RoleDto>();
            //CreateMap<IList<SP_Ut_admin_getmenudetails>, RoleDto>()
            //    .ForMember(des => des.pki_role_id, option => option.Ignore())
            //    .ForMember(des => des._MenuDto, option => option
            //                .MapFrom(src => (new1.Map<List<SP_Ut_admin_getmenudetails>, IList<MenuDTO>>(src.ToList()))
            //                    .Select(x => new MenuDTO {
            //                        fki_parent_id = x.fki_parent_id,
            //                        pki_menu_id = x.pki_menu_id
            //                    }))
            //    );

            CreateMap<IList<SP_Ut_admin_getmenudetails>, RoleDto>()
                .ForMember(des => des.pki_role_id, opt => opt.MapFrom(src => src[0].pki_role_id))
                .ForMember(des => des._MenuDto, option => option.MapFrom(src => src.Select(x => new MenuDTO
                {
                    pki_menu_id = x.pki_menu_id,
                    fki_parent_id = x.fki_parent_id,
                    vc_menu = x.vc_menu,
                    vc_menu_controller = x.vc_menu_controller,
                    vc_menu_action = x.vc_menu_action,
                    vc_menu_icon = x.vc_menu_icon
                })))
            ;

            CreateMap<IList<SP_Ut_admin_getmenudetails>, LoginDto>()
                .ForMember(des => des.pki_user_id, opt => opt.Ignore())
                .ForMember(des => des.vc_name, opt => opt.Ignore())
                .ForMember(des => des.vc_email, opt => opt.Ignore())
                .ForMember(des => des.b_isreset, opt => opt.Ignore())
               // .ForMember(des => des._RoleDto, option => option.MapFrom <IList<SP_Ut_admin_getmenudetails>, RoleDto,null>() )
                ;


            //CreateMap<IList<SP_Ut_admin_getmenudetails>, LoginDto>()
            //    .ForMember(des => des._RoleDto, option => option.MapFrom(src => new1.Map<IList<SP_Ut_admin_getmenudetails>, RoleDto>(src)));
            //;

        }
}
}
