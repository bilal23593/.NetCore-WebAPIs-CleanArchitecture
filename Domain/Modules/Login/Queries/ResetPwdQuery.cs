using Domain.Modules.Login.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modules.Login.Queries
{
    public class ResetPwdQuery : IRequest<LoginDto>
    {
    }
}
