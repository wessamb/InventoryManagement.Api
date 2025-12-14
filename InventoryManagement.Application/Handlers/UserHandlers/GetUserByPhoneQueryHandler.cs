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
    public class GetUserByPhoneQueryHandler : IRequestHandler<GetUserByPhoneQuery, User>
    {
        private readonly IUserRepository _user;
        private readonly ILogger<GetUserByPhoneQueryHandler> _logger;
        public GetUserByPhoneQueryHandler(IUserRepository user, ILogger<GetUserByPhoneQueryHandler>logger) {  _user = user;_logger = logger; }
        public async Task<User> Handle(GetUserByPhoneQuery request, CancellationToken cancellationToken)
        {
         var users= await _user.GetUserByPhoneAsync(request.phone);
            return users;
        }
    }
}
