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
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _user;
        private readonly ILogger<GetAllUsersQueryHandler> _logger;
        public GetAllUsersQueryHandler(IUserRepository user, ILogger<GetAllUsersQueryHandler> logger)
        {
            _logger = logger;
            _user = user;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _user.GetAllUsersAsync(request.PageNumber,request.PageNumber);
            return users;
        }
    }
}
