using MediatR;

namespace UseCases.Handlers.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
