using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure.Interfaces.DataAccess;

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
                .Include(i => i.Creator)
                .Select(s => new IssueDto
                {
                    Id = s.IssueId,
                    Name = s.Name,
                    StatusName = s.Status.Name,
                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.Creator.FullName
                }).OrderBy(o => o.CreatedAt).ToListAsync(cancellationToken);

            return new IssuesListVm
            {
                Issues = issues
            };
        }
    }
}
