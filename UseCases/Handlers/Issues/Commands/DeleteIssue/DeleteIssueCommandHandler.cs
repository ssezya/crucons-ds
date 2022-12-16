using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;
using UseCases.Exceptions;

namespace UseCases.Handlers.Issues.Commands.DeleteIssue
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteIssueCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Issues.FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Issue), request.Id);

            _dbContext.Issues.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
