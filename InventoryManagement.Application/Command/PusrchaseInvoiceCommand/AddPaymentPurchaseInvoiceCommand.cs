using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InventoryManagement.Application.Command.PusrchaseInvoiceCommand
{
    public sealed record  AddPaymentPurchaseInvoiceCommand(int invoiceId, decimal amount, PaymentMethod method, int userId) :IRequest<string>;
}
