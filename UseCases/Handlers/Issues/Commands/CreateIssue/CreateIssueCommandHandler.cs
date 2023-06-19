using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Identity.Services;
using Entities.Models;

namespace UseCases.Handlers.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public CreateIssueCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Issues.Add(new Issue
            {
                Title = request.Title,
                Description = request.Description,
                ProjectId = request.ProjectId,
                ReporterId = _currentUserService.EmployeeId, // Current system user
                ExecutorId = request.ExecutorId
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
