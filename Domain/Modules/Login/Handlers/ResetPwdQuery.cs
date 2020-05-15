using AutoMapper;
using Data.IRepositories;
using Database.Entities.Modules.Login;
using Domain.Modules.Login.DTOs;
using Domain.Modules.Login.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Modules.Login.Handlers
{
    public class ResetPwdQuery : IRequestHandler<GetUserQuery, LoginDto>
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        public ResetPwdQuery(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<LoginDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            //return _mapper
            //         .Map<UT_Admin_User, LoginDto>
            //         (await _loginRepository.GetUser(_mapper.Map<LoginDto, UT_Admin_User>(request._loginDto)));
            LoginDto log = new LoginDto();
            return log;
        }

    }
}
