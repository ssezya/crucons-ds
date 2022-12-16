using System.Collections.Generic;
using MediatR;

namespace UseCases.Handlers.Employees.Queries.GetEmployeesList
{
    public class EmployeesListVm : IRequest
    {
        public ICollection<EmployeeDto> Employees { get; set; }
    }
}
