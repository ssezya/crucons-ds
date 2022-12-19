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
                .Include(i => i.Notes)
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
                    Notes = i.Notes.Select(n => new IssueNoteDto
                    {
                        Id = n.Id,
                        Description = n.Description,
                        WriterName = n.Writer.FullName
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            if (vm == null)
                throw new NotFoundException(nameof(Issue), request.Id);

            return vm;
        }
    }
}
