using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InventoryManagement.Application.Command.TransactionCommand
{
    public sealed record  UpdateTransactionCommand(
        int transId,
        decimal Amount,
         TransactionType Type,
         PaymentMethod PaymentMethod,
         string Description,
         DateTime Date,
         int? PurchaseInvoiceId,
         int? SalesInvoiceId) :IRequest<Transaction>;
}
