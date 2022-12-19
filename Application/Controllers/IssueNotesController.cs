using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Handlers.IssueNotes.Commands.CreateIssueNote;

namespace Application.Controllers
{
    [Authorize]
    public class IssueNotesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIssueNoteCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
