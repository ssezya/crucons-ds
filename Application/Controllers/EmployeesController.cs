using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Handlers.Employees.Queries.GetEmployeesList;
using UseCases.Handlers.Employees.Commands.CreateEmployee;

namespace Application.Controllers
{
    public class EmployeesController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<EmployeesListVm>> GetAll() => Ok(await Mediator.Send(new GetEmployeesListQuery()));

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
