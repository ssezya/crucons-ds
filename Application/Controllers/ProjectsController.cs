using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Handlers.Projects.Queries.GetProjectsList;
using UseCases.Handlers.Projects.Commands.CreateProject;

namespace Application.Controllers
{
    [Authorize]
    public class ProjectsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProjectsListVm>> GetAll() => Ok(await Mediator.Send(new GetProjectsListQuery()));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
