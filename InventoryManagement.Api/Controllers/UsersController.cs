using InventoryManagement.Application.Command.UserCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber=1, int pageSize=10)
        {
            var result= await _mediator.Send(new InventoryManagement.Application.Queries.UserQueries.GetAllUsersQuery(pageNumber, pageSize));
            return Ok(result);
        }
        [Authorize(Roles = "Admin,Sales")]
        [HttpGet("GetUserByRole/{id}")]
        public async Task<IActionResult> GetUsersByRole(int id, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(new InventoryManagement.Application.Queries.UserQueries.GetUsersByRoleQuery(id,pageNumber,pageSize));
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("UserBy/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new InventoryManagement.Application.Queries.UserQueries.GetUserByIdQuery(id));
            return Ok(user);
        }
        [Authorize(Roles = "Admin,Sales")]
        [HttpGet("GetByPhone/{phone}")]
        public async Task<IActionResult> GetUserByPhone(string phone)
        {
            var user = await _mediator.Send(new InventoryManagement.Application.Queries.UserQueries.GetUserByPhoneQuery(phone));
            return Ok(user);
        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginCommand loginCommand )
        {
            var token = await _mediator.Send(loginCommand);

          
            return Ok(new { token });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("activate/{id}")]
        public async Task<IActionResult> ActivateUser(int id)
        {
            var user = await _mediator.Send(new InventoryManagement.Application.Command.UserCommand.ActivateUserCommand(id));
            return Ok(user);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost("deactivate/{id}")]
        public async Task<IActionResult> DeactivateUser(int id)
        {
            var user = await _mediator.Send(new InventoryManagement.Application.Command.UserCommand.DeactivateUserCommand(id));
            return Ok(user);

        }
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(InventoryManagement.Application.Command.UserCommand.RegisterUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("ChangeRole/{id}")]
        public async Task<IActionResult> ChangeUserRole(int id, int newRoleId)
        {
            var user = await _mediator.Send(new InventoryManagement.Application.Command.UserCommand.ChangeRoleCommand(id, newRoleId));
            return Ok(user);
        }


        } 
}
