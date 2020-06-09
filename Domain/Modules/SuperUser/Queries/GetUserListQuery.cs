using Domain.Modules.SuperUser.DTOs;
using Domain.Modules.SuperUser.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.SuperUser.Queries
{
    public class GetUserListQuery : IRequest<UserDtoList>
    {
        public GetUserListQuery()
        {
        }
    }
}
