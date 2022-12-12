using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Handlers.Jobs.Commands.CreateJob;

namespace Application.Controllers
{
    [Authorize]
    public class JobsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
