using AutoMapper;
using Data.Util;
using Database;
using Database.Entities.Modules.Login;
using Domain.Modules.Login.Commands;
using Domain.Modules.Login.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Modules.Login.Handlers
{
    class UpsertUserCommandHandler : IRequestHandler<UpsertUserCommand, LoginDto>
    {
        UHSUtil _Util = new UHSUtil();
        private readonly IMapper _mapper;
        private readonly UHSToolDBContext _dbContext;
        public UpsertUserCommandHandler(IMapper mapper, UHSToolDBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<LoginDto> Handle(UpsertUserCommand request, CancellationToken cancellationToken)
        {
            UT_Admin_User entity;

            if (request._loginDto.pki_user_id > 0 && request._loginDto != null)
            {
                entity = await _dbContext.UT_Admin_User
                                        .SingleOrDefaultAsync(c => c.pki_user_id == request._loginDto.pki_user_id, cancellationToken);
                entity.vc_name = request._loginDto.vc_name;
                entity.vc_email = request._loginDto.vc_email;
                entity.vc_password = _Util.EncryptString(request._loginDto.vc_password);
            }
            else
            {            
                entity = _mapper.Map<LoginDto, UT_Admin_User>(request._loginDto);
                _dbContext.UT_Admin_User.Add(entity);
            }
            
            await _dbContext.SaveChangesAsync(cancellationToken);   

            return request._loginDto;
        }
    }
}
