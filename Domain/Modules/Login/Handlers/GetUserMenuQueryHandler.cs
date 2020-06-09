using AutoMapper;
using Data.Util;
using Database;
using Database.Entities.Modules.Login.ViewModels;
using Domain.Modules.Login.DTOs;
using Domain.Modules.Login.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Modules.Login.Handlers
{
    public class GetUserMenuQueryHandler : IRequestHandler<GetUserMenuQuery, RoleDto>
    {
        UHSUtil _Util = new UHSUtil();
        private readonly IMapper _mapper;
        private readonly UHSToolDBContext _dbContext;
        public GetUserMenuQueryHandler(IMapper mapper, UHSToolDBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<RoleDto> Handle(GetUserMenuQuery request, CancellationToken cancellationToken)
        {

            var UserDetails = _dbContext.__SP_Ut_admin_getmenudetails
                                            .FromSqlRaw("Ut_admin_getmenudetails {0}, {1}",
                                                request._loginDto._RoleDto[0].pki_role_id,
                                                request._loginDto.pki_user_id)
                                            .ToList();

            //var UserDetails3 = _mapper.Map<IList<SP_Ut_admin_getmenudetails>, IList<MenuDTO>>(UserDetails);

            var UserDetails1 = _mapper.Map<IList<SP_Ut_admin_getmenudetails>, RoleDto>(UserDetails);
           // var UserDetails2 = _mapper.Map<IList<RoleDto>, IList<LoginDto>>(UserDetails1);

            //var UserDetails2 = _mapper.Map<IList<SP_Ut_admin_getmenudetails>, LoginDto>(UserDetails);

            return await Task.Run(() =>
            {
                return UserDetails1;
            });

        }
    }
}
