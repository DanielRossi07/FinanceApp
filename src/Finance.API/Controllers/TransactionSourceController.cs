using Finance.API.ApiModels.TransactionSource;
using Finance.Application.UseCases.TransactionSource;
using Finance.Application.UseCases.TransactionSource.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionSourceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionSourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionSourceModelOutput), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateTransactionSourceInput input, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(input, cancellationToken);
            return CreatedAtAction(
                nameof(Create), 
                new { output.Id }, 
                output
            );
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TransactionSourceModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetTransactionSourceInput(id), cancellationToken);
            return Ok(output);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(TransactionSourceModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update([FromBody] UpdateTransactionSourceApiInput apiInput, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var input = new UpdateTransactionSourceInput(id, apiInput.Name, apiInput.BankAccountId, apiInput.Type);

            var output = await _mediator.Send(input, cancellationToken);
            return Ok(output);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(TransactionSourceModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new DeleteTransactionSourceInput(id), cancellationToken);
            return Ok(output);
        }
    }
}