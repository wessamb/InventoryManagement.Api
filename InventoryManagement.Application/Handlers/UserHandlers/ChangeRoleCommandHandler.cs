using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Command.UserCommand;
using InventoryManagement.Application.Interface;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Handlers.UserHandlers
{
    public class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand, string>
    {
        private readonly IUserRepository _user;
        private readonly ILogger<ChangeRoleCommandHandler> _logger;
        public ChangeRoleCommandHandler( IUserRepository user, ILogger<ChangeRoleCommandHandler> logger)
        {
            _logger = logger;
            _user = user;
        }
        public async Task<string> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            var users = await _user.ChangeRoleAsync(request.UserId, request.NewRoleId);
            return users;

        }
    }
}
