using AutoMapper;
using Database;
using Database.Entities.Modules.Login;
using Domain.Modules.SuperUser.DTOs;
using Domain.Modules.SuperUser.Queries;
using Domain.Modules.SuperUser.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Modules.SuperUser.Handlers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserDtoList>
    {
        //UHSUtil _Util = new UHSUtil();
        private readonly IMapper _mapper;
        private readonly UHSToolDBContext _dbContext;
        public GetUserListQueryHandler(IMapper mapper, UHSToolDBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<UserDtoList> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
           var UserDetails = _dbContext.UT_Admin_User.ToList();
            //var UserDetails = (from  user in _dbContext.UT_Admin_User
            //  let user.
            //   select  user  ).ToList();
        
            if (UserDetails.Count > 0)
            {
               // return _mapper.Map<IList<UT_Admin_User>, UserDtoList>(UserDetails);
            }
            return await Task.Run(() =>
            {  
                return new UserDtoList();
            });
        }
    }
}
