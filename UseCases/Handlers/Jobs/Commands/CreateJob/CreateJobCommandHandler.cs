using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;

namespace UseCases.Handlers.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateJobCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Jobs.Add(new Job
            {
                IssueId = request.IssueId,
                ActionId = request.ActionId,
                Description = request.Description
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
