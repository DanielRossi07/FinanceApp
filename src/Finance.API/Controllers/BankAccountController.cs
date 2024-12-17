using Finance.API.ApiModels.BankAccount;
using Finance.Application.UseCases.BankAccount;
using Finance.Application.UseCases.BankAccount.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BankAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BankAccountModelOutput), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateBankAccountInput input, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(input, cancellationToken);
            return CreatedAtAction(
                nameof(Create), 
                new { output.Id }, 
                output
            );
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(BankAccountModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetBankAccountInput(id), cancellationToken);
            return Ok(output);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(BankAccountModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update([FromBody] UpdateBankAccountApiInput apiInput, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var input = new UpdateBankAccountInput(id, apiInput.Name);

            var output = await _mediator.Send(input, cancellationToken);
            return Ok(output);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(BankAccountModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new DeleteBankAccountInput(id), cancellationToken);
            return Ok(output);
        }
    }
}