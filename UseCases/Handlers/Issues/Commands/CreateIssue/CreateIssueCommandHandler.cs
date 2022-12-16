using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;

namespace UseCases.Handlers.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateIssueCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Issues.Add(new Issue
            {
                Title = request.Title,
                Description = request.Description,
                ProjectId = request.ProjectId,
                ReporterId = request.ReporterId,
                ExecutorId = request.ExecutorId
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
