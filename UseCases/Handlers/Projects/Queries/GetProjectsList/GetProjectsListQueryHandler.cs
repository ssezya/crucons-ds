using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure.Interfaces.DataAccess;

namespace UseCases.Handlers.Projects.Queries.GetProjectsList
{
    public class GetProjectsListQueryHandler : IRequestHandler<GetProjectsListQuery, ProjectsListVm>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetProjectsListQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectsListVm> Handle(GetProjectsListQuery request, CancellationToken cancellationToken)
        {
            var projectsList = await _dbContext.Projects
                .AsNoTracking()
                .Select(s => new ProjectDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .OrderBy(o => o.Id)
                .ToListAsync(cancellationToken);

            return new ProjectsListVm
            {
                Projects = projectsList
            };
        }
    }
}
