using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using MediatR;

namespace InventoryManagement.Application.Queries.UserQueries
{
    public sealed record GetUsersByRoleQuery(int RoleId,int PageNumber = 1, int PageSize = 10) : IRequest<IEnumerable<User>>;
}
