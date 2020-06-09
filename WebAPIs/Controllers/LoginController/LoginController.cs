using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Modules.Login.Commands;
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

        [HttpPost]
        public async Task<ActionResult<LoginDto>> ResetPwd([FromBody] LoginDto _obj)
        {
            return await Mediator.Send(new ResetPwdCommand(_obj));
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> UserRoleDetails([FromBody] LoginDto _obj)
        {
            return await Mediator.Send(new GetUserMenuQuery(_obj));
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(LoginDto _obj)
        {
            var id = await Mediator.Send(new UpsertUserCommand(_obj));
            return Ok(id);
        }
    }
}