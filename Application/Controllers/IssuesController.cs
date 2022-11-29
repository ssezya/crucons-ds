using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UseCases.Handlers.Issues.Queries.GetIssuesList;
using UseCases.Handlers.Issues.Queries.GetIssueDetail;
using UseCases.Handlers.Issues.Commands.CreateIssue;

namespace Application.Controllers
{
    public class IssuesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IssuesListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetIssuesListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IssueDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetIssueDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateIssueCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
