using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InventoryManagement.Application.Command.UserCommand
{
    public sealed record ActivateUserCommand(int UserId):IRequest<string>;
}
