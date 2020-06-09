using Domain.Modules.Login.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.Commands
{
    public class ResetPwdCommand : IRequest<LoginDto>
    {
        public LoginDto _loginDto = new LoginDto();
        public ResetPwdCommand(LoginDto userDto)
        {
            _loginDto = userDto;
        }
    }
}
