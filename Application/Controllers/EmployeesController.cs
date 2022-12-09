using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.Handlers.Employees.Commands.CreateEmployee;

namespace Application.Controllers
{
    public class EmployeesController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
