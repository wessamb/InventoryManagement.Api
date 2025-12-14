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
    public class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand, string>
    {
        private readonly IUserRepository _user;
        private readonly  ILogger<DeactivateUserCommandHandler> _logger;
        public DeactivateUserCommandHandler(IUserRepository user, ILogger<DeactivateUserCommandHandler> logger)
        {
            _logger = logger;
            _user = user;
        }

        public async Task<string> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            var users = await _user.DeactivateUserAsync(request.UserId);
            return users;
        }
    }
}
