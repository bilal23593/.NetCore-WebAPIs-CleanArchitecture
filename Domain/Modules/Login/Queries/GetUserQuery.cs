using Domain.Modules.Login.DTOs;
using Domain.Modules.Login.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.Queries
{
    public class GetUserQuery : IRequest<LoginDto>
    {
        public LoginDto _loginDto = new LoginDto();
        public GetUserQuery(LoginDto userDto)
        {
            _loginDto = userDto;
        }
    }
}
