using AutoMapper;
using Data.IRepositories;
using Data.Util;
using Database;
using Domain.Modules.Login.Commands;
using Domain.Modules.Login.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Modules.Login.Handlers
{
    public class ResetPwdCommandHandler : IRequestHandler<ResetPwdCommand, LoginDto>
    {
        UHSUtil _Util = new UHSUtil();
        private readonly IMapper _mapper;
        private readonly UHSToolDBContext _dbContext;
        public ResetPwdCommandHandler(IMapper mapper, UHSToolDBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<LoginDto> Handle(ResetPwdCommand request, CancellationToken cancellationToken)
        {
            var UserDetails = await _dbContext.UT_Admin_User
                                        .SingleOrDefaultAsync(c => c.pki_user_id == request._loginDto.pki_user_id, cancellationToken);

            UserDetails.vc_password = _Util.EncryptString(request._loginDto.vc_password).ToString();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return null;
        }

    }
}
