using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Utils.Extensions;

namespace UseCases.Handlers.Issues.Queries.GetIssuesList
{
    public class GetIssuesListQueryHandler : IRequestHandler<GetIssuesListQuery, IssuesListVm>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetIssuesListQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IssuesListVm> Handle(GetIssuesListQuery request, CancellationToken cancellationToken)
        {
            var issues = await _dbContext.Issues
                .AsNoTracking()
                .Select(s => new IssueDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    ProjectName = s.Project.Name,
                    ReporterName = s.Reporter.FullName,
                    StatusName = s.StatusId.GetDisplayName(),
                    ExecutorName = s.Executor.FullName
                }).OrderBy(o => o.Id).ToListAsync(cancellationToken);

            return new IssuesListVm
            {
                Issues = issues
            };
        }
    }
}
