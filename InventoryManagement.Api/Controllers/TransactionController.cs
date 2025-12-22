using InventoryManagement.Application.Command.TransactionCommand;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] InventoryManagement.Application.Command.TransactionCommand.AddTransactionCommand command)
        {
            var transaction = await _mediator.Send(command);
            return Ok(transaction);
        }
        [HttpDelete("DeleteTransaction/{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var result = await _mediator.Send(new InventoryManagement.Application.Command.TransactionCommand.DeleteTransactionCommand(id));
            return Ok(result);
        }
        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _mediator.Send(new InventoryManagement.Application.Queries.TransactionQueries.GetAllTransactionsQuery());
            return Ok(transactions);
        }
        [HttpGet("GetTransactionById/{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transaction = await _mediator.Send(new InventoryManagement.Application.Queries.TransactionQueries.GetTransactionByIdQuery(id));
            return Ok(transaction);
        }
        [HttpGet("GetByPurchaseInvoice/{id}")]
        public async Task<IActionResult> GetTransactionsByPurchaseId(int id)
        {
            var transactions = await _mediator.Send(new InventoryManagement.Application.Queries.TransactionQueries.GetByPurchaseInvoiceQuery(id));
            return Ok(transactions);
        }
        [HttpGet("GetBySalesInvoice/{id}")]
        public async Task<IActionResult> GetTransactionsBySalesInvoiceId(int id)
        {
            var transactions = await _mediator.Send(new InventoryManagement.Application.Queries.TransactionQueries.GetBySalesInvoiceQuery(id));
            return Ok(transactions);
        }
        [HttpGet("GetByUserTransaction/{id}")]
        public async Task<IActionResult> GetTransactionsByUserId(int id)
        {
            var transactions = await _mediator.Send(new InventoryManagement.Application.Queries.TransactionQueries.GetByUserQuery(id));
            return Ok(transactions);
        }
        [HttpGet("GetByType/{type}")]
        public async Task<IActionResult> GetTransactionsByType(string type)
        {
            if (!Enum.TryParse(type, true, out TransactionType transactionType))
            {
                return BadRequest("Invalid transaction type.");
            }
            var transactions = await _mediator.Send(new InventoryManagement.Application.Queries.TransactionQueries.GetTransactionsByTypeQuery(transactionType));
            return Ok(transactions);
        }
        [HttpGet("GetToTalAmountBy/{type}")]
        public async Task<IActionResult> GetTotalAmountByType(string type)
        {
            if (!Enum.TryParse(type, true, out TransactionType transactionType))
            {
                return BadRequest("Invalid transaction type.");
            }
            var totalAmount = await _mediator.Send(new InventoryManagement.Application.Queries.TransactionQueries.GetTotalAmountByTypeQuery(transactionType));
            return Ok(totalAmount);
        }
        [HttpGet("GetTransactionsInDateRange")]
        public async Task<IActionResult> GetTransactionsInDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var transactions = await _mediator.Send(new InventoryManagement.Application.Queries.TransactionQueries.GetTransactionsByDateRangeQuery(startDate, endDate));
            return Ok(transactions);
        }
        [HttpPut("UpdateTransaction/{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] UpdateTransactionCommand updateTransaction)
        {
            if (id != updateTransaction.transId)
            {
                return BadRequest("ID in URL does not match ID in body");
            }
            var result = await _mediator.Send(updateTransaction);
            return Ok(result);
        }
    }
}
