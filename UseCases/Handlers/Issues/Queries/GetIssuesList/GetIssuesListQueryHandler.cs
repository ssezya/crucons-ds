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
        private readonly IDbContext _dbContext;

        public GetIssuesListQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IssuesListVm> Handle(GetIssuesListQuery request, CancellationToken cancellationToken)
        {
            var issues = await _dbContext.Issues.Select(s => new IssueDto
            {
                Id = s.IssueId,
                Name = s.Name,
                StatusName = s.Status.Name,
                CreatedAt = s.CreatedAt
            }).OrderBy(o => o.CreatedAt).ToListAsync(cancellationToken);

            return new IssuesListVm
            {
                Issues = issues
            };
        }
    }
}
