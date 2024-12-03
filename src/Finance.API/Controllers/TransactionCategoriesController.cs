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
    }
}