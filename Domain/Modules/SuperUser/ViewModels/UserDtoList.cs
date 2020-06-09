using Domain.Modules.SuperUser.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.SuperUser.ViewModels
{
    public class UserDtoList
    {
        public IList<UserDto> userDtoList { get; set; }
    }
}
