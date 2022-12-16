using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure.Interfaces.DataAccess;

namespace UseCases.Handlers.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, EmployeesListVm>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetEmployeesListQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeesListVm> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var employees = await _dbContext.Employees
                .AsNoTracking()
                .Select(s => new EmployeeDto
                {
                    Id = s.Id,
                    FullName = s.FullName
                }).OrderBy(o => o.Id).ToListAsync(cancellationToken);

            return new EmployeesListVm
            {
                Employees = employees
            };
        }
    }
}
