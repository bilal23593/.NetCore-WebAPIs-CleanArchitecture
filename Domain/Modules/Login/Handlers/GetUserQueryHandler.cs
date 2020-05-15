using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.IRepositories;
using Data.Util;
using Database;
using Domain.Modules.Login.DTOs;
using Domain.Modules.Login.Queries;
using Domain.Modules.Login.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Modules.Login.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, LoginDto>
    {
        UHSUtil _Util = new UHSUtil();
        private readonly IMapper _mapper;
        private readonly UHSToolDBContext _dbContext;
        public GetUserQueryHandler(IMapper mapper, UHSToolDBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<LoginDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user= _dbContext._VM_UserRole
                            .FromSqlRaw("Ut_admin_getuserdetails {0}, {1}", request._loginDto.vc_username.ToUpper().ToString(),
                                                        _Util.EncryptString(request._loginDto.vc_password).ToString())
                            .ProjectTo<VM_UserRoleDto>(_mapper.ConfigurationProvider)
                            .ToList();
            LoginDto use = new LoginDto();
            return use;
        }
    }
}
