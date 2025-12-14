using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Entites;
using MediatR;

namespace InventoryManagement.Application.Command.UserCommand
{
    public sealed record RegisterUserCommand(string fullname,string phone,int RoleId,string Password):IRequest<User>;
}
