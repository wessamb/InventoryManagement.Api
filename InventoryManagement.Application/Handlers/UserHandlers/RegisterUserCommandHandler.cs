using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Command.UserCommand;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Handlers.UserHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IAuthService _user;

        public RegisterUserCommandHandler(IAuthService user)
        {
            _user = user;

        }
        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
          var users= await _user.RigisterAsync(request.fullname,request.phone,request.RoleId,request.Password);
            return users;
        }
    }
}
