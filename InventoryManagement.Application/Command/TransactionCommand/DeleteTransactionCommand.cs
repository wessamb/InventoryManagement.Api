using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InventoryManagement.Application.Command.TransactionCommand
{
    public sealed record DeleteTransactionCommand(int TransactionId):IRequest<string>;
}
