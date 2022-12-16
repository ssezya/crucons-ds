using MediatR;

namespace UseCases.Handlers.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IRequest<EmployeesListVm> { }
}
