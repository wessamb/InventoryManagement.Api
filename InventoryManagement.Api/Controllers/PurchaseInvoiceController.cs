using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseInvoiceController: ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseInvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAllPurchaseInvoce")]
        public async Task<IActionResult> GetAll() { 
        var result= await _mediator.Send( new InventoryManagement.Application.Queries.PusrchaseInvoiceQueries.GetAllPurchaseInvoceQuery());
            return CreatedAtAction(nameof(GetAll), result);
        }
        [HttpPost("CreatePurchaseInvoice")]
        public async Task<IActionResult> CreatePurchaseInvoice([FromBody] InventoryManagement.Application.Command.PusrchaseInvoiceCommand.CreatePusrchaseInvoiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("{id}/payments")]
        public async Task<IActionResult> UpdatePurchaseInvoice(int id,[FromBody] InventoryManagement.Application.Command.PusrchaseInvoiceCommand.AddPaymentPurchaseInvoiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
