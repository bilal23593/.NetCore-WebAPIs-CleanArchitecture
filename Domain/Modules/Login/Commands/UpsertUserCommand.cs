using Domain.Modules.Login.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.Commands
{
    public class UpsertUserCommand : IRequest<LoginDto>
    {
        public LoginDto _loginDto = new LoginDto();
        public UpsertUserCommand(LoginDto userDto)
        {
            _loginDto = userDto;
        }
    }
}
