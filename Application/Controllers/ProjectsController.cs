using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Handlers.Projects.Commands.CreateProject;

namespace Application.Controllers
{
    public class ProjectsController : BaseController
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
