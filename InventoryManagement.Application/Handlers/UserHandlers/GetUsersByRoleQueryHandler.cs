using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Common;
using InventoryManagement.Application.Entites;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Queries.UserQueries;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Handlers.UserHandlers
{
    public class GetUsersByRoleQueryHandler : IRequestHandler<GetUsersByRoleQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _user;

        private readonly ILogger<GetUsersByRoleQueryHandler> _logger;
        public GetUsersByRoleQueryHandler(IUserRepository user, ILogger<GetUsersByRoleQueryHandler> logger) { _user = user; _logger = logger; }
        public async Task<IEnumerable<User>> Handle(GetUsersByRoleQuery request, CancellationToken cancellationToken)
        {
            var users = await _user.GetAllUsersByRolesAsync(request.RoleId,request.PageNumber,request.PageSize);
            return users;

        }
    }
}
