using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UseCases.Handlers.Issues.Queries.GetIssuesList;
using UseCases.Handlers.Issues.Queries.GetIssueDetail;
using UseCases.Handlers.Issues.Commands.CreateIssue;
using UseCases.Handlers.Issues.Commands.UpdateIssue;
using UseCases.Handlers.Issues.Commands.DeleteIssue;
using UseCases.Handlers.Issues.Commands.CreateIssueNote;

namespace Application.Controllers
{
    [Authorize]
    public class IssuesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IssuesListVm>> GetAll() => Ok(await Mediator.Send(new GetIssuesListQuery()));

        [HttpGet("{id}")]
        public async Task<ActionResult<IssueDetailVm>> Get(int id) => Ok(await Mediator.Send(new GetIssueDetailQuery { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIssueCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateIssueDto dto)
        {
            await Mediator.Send(new UpdateIssueCommand(id, dto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteIssueCommand { Id = id });

            return NoContent();
        }

        [HttpPost("notes")]
        public async Task<IActionResult> CreateIssueNote([FromBody] CreateIssueNoteCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
