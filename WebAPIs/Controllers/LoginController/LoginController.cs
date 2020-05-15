using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Modules.Login.DTOs;
using Domain.Modules.Login.Queries;
using Domain.Modules.Login.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers.LoginController
{
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// Check Login User by UserCredentials
        /// 
        [HttpPost]
        public async Task<ActionResult<LoginDto>> UserLogin([FromBody] LoginDto _obj)
        {
            return await Mediator.Send(new GetUserQuery(_obj));
        }
    }
}