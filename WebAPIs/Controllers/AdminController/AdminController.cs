using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Modules.SuperUser.Queries;
using Domain.Modules.SuperUser.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIs.Controllers.AdminController
{
    [ApiController]
    [Produces("application/json")]
    public class AdminController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<UserDtoList>> GetUserList()
        {
            return await Mediator.Send(new GetUserListQuery());
        }
    }
}