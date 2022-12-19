using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Identity.Services;
using Entities.Models;

namespace UseCases.Handlers.Issues.Commands.CreateIssueNote
{
    public class CreateIssueNoteCommandHandler : IRequestHandler<CreateIssueNoteCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUser;

        public CreateIssueNoteCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUser)
        {
            _dbContext = dbContext;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(CreateIssueNoteCommand request, CancellationToken cancellationToken)
        {
            _dbContext.IssueNotes.Add(new IssueNote
            {
                IssueId = request.IssueId,
                Description = request.Description,
                WriterId = _currentUser.EmployeeId
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
