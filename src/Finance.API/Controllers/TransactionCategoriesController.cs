using Finance.API.ApiModels.TransactionCategory;
using Finance.Application.UseCases.TransactionCategory;
using Finance.Application.UseCases.TransactionCategory.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransactionCategoryModelOutput), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Create([FromBody] CreateTransactionCategoryInput input, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(input, cancellationToken);
            return CreatedAtAction(
                nameof(Create), 
                new { output.Id }, 
                output
            );
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TransactionCategoryModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new GetTransactionCategoryInput(id), cancellationToken);
            return Ok(output);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(TransactionCategoryModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update([FromBody] UpdateTransactionCategoryApiInput apiInput, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var input = new UpdateTransactionCategoryInput(id, apiInput.Name, apiInput.Description!);

            var output = await _mediator.Send(input, cancellationToken);
            return Ok(output);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(TransactionCategoryModelOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new DeleteTransactionCategoryInput(id), cancellationToken);
            return Ok(output);
        }
    }
}