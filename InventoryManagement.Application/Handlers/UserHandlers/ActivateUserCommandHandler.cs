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
    public class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, string>
    {
        private readonly IUserService _user;
        private readonly ILogger<ActivateUserCommandHandler>_logger;
        public ActivateUserCommandHandler(IUserService user)
        {
            _user = user;
        
        }

        public async Task<string> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
          await _user.ActivateAsync(request.UserId);
           
            return "exchange the status";

        }
    }
}
