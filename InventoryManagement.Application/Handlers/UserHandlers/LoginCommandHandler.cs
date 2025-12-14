using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Command.UserCommand;
using InventoryManagement.Application.Exceptions;
using InventoryManagement.Application.Interface;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Handlers.UserHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _user;
        
        private readonly ILogger<LoginCommandHandler>_logger;
        public LoginCommandHandler(IUserRepository user, ILogger<LoginCommandHandler>logger)
        {
_user= user;
            _logger = logger;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var users = await _user.LoginAsync(request.phone, request.password);
            if (users == null)
            {
                _logger.LogWarning("Login failed for email: {phone}", request.phone);
                throw new AuthenticationException("Invalid email or password.");
            }
            _logger.LogInformation("User logged in successfully: {phone}", request.phone);
            return users;

        }
    }
}
