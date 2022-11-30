using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;
using UseCases.Exceptions;

namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class GetIssueDetailQueryHandler : IRequestHandler<GetIssueDetailQuery, IssueDetailVm>
    {
        private readonly IDbContext _dbContext;

        public GetIssueDetailQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IssueDetailVm> Handle(GetIssueDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _dbContext.Issues.AsNoTracking()
                .Where(w => w.IssueId == request.Id)
                .Select(i => new IssueDetailVm
                {
                    Id = i.IssueId,
                    Name = i.Name,
                    Description = i.Description,
                    StatusName = i.Status.Name,
                    CreatedAt = i.CreatedAt,
                    LastModifiedAt = i.LastModifiedAt,
                    Jobs = i.Jobs.Select(j => new IssueJobDto
                    {
                        JobId = j.JobId,
                        Description = j.Description,
                        ActionName = j.Action.ActionName,
                        CreatedAt = j.CreatedAt
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            if (vm == null)
                throw new NotFoundException(nameof(Issue), request.Id);

            return vm;
        }
    }
}
