using AutoMapper;
using Data.IRepositories;
using Data.Util;
using Database;
using Database.Entities.Modules.Login;
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

            var UserDetails = _dbContext.__SP_Ut_admin_getuserdetails.FromSqlRaw("Ut_admin_getuserdetails {0}, {1}",
                                                request._loginDto.vc_username.ToUpper().ToString(),
                            _Util.EncryptString(request._loginDto.vc_password).ToString())
                                                .ToList();

            if (UserDetails.Count > 0)
            {
                var userMapper = _mapper.Map<IList<SP_Ut_admin_getuserdetails>, LoginDto>(UserDetails);
                if (userMapper.b_isreset == false)
                {
                    return userMapper;
                }
            }

            return await Task.Run(() =>
                {
                    return new LoginDto();
                });
            
        }
        public LoginDto MapSP_Ut_admin_getuserdetails(IList<SP_Ut_admin_getuserdetails> UserDetails)
        {
            return _mapper.Map<IList<SP_Ut_admin_getuserdetails>, LoginDto>(UserDetails);
        }
    }
}
