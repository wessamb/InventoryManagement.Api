using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Command.UserCommand;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Handlers.UserHandlers
{
    public class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand, string>
    {
        private readonly IUserService _user;
        private readonly  ILogger<DeactivateUserCommandHandler> _logger;
        public DeactivateUserCommandHandler(IUserService user, ILogger<DeactivateUserCommandHandler> logger)
        {
            _logger = logger;
            _user = user;
        }

        public async Task<string> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
             await _user.DeactivateUserAsync(request.UserId);
            return "exchange to Deactivate";
        }
    }
}
