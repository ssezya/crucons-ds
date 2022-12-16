using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;
using UseCases.Exceptions;
using Utils.Extensions;

namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class GetIssueDetailQueryHandler : IRequestHandler<GetIssueDetailQuery, IssueDetailVm>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetIssueDetailQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IssueDetailVm> Handle(GetIssueDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _dbContext.Issues
                .AsNoTracking()
                .Include(i => i.Jobs)
                .Where(w => w.Id == request.Id)
                .Select(i => new IssueDetailVm
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    ProjectName = i.Project.Name,
                    ReporterName = i.Reporter.FullName,
                    StatusName = i.StatusId.GetDisplayName(),
                    ExecutorName = i.Executor.FullName,
                    Jobs = i.Jobs.Select(j => new IssueJobDto
                    {
                        Id = j.Id,
                        Description = j.Description,
                        ExecutorName = j.Executor.FullName,
                        ActionName = j.ActionId.GetDisplayName()
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            if (vm == null)
                throw new NotFoundException(nameof(Issue), request.Id);

            return vm;
        }
    }
}
