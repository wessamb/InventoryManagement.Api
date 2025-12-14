using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Queries.UserQueries;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _user;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;
        public GetUserByIdQueryHandler( IUserRepository user,ILogger<GetUserByIdQueryHandler>logger)
        {
            _user = user;
            _logger = logger;
        }   
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _user.GetUserByIdAsync(request.UserID);
            return users;
        }
    }
}
