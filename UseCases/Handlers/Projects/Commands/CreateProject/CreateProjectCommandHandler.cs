using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;

namespace UseCases.Handlers.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateProjectCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Projects.Add(new Project
            {
                Name = request.Name
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
