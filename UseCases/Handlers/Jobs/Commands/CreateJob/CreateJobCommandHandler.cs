using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Infrastructure.Interfaces.Identity.Services;
using Entities.Models;

namespace UseCases.Handlers.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUser;

        public CreateJobCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUser)
        {
            _dbContext = dbContext;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Jobs.Add(new Job
            {
                IssueId = request.IssueId,
                ActionId = request.ActionId,
                Description = request.Description,
                ExecutorId = _currentUser.EmployeeId
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
