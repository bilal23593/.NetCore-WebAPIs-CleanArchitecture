using Domain.Modules.Login.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.Queries
{
    public class GetUserMenuQuery : IRequest<RoleDto>
    {
        public LoginDto _loginDto = new LoginDto();
        public GetUserMenuQuery(LoginDto loginDto)
        {
            _loginDto = loginDto;
        }
    }
}
