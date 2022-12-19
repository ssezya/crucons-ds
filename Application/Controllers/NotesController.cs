using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Handlers.Notes.Commands.CreateNote;

namespace Application.Controllers
{
    [Authorize]
    public class NotesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
