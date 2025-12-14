using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using MediatR;

namespace InventoryManagement.Application.Queries.UserQueries
{
    public sealed record  GetUserByIdQuery(int UserID) :IRequest<User> ;
}
