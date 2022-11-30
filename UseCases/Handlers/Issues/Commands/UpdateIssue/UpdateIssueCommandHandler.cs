using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Infrastructure.Interfaces.DataAccess;
using Entities.Models;
using UseCases.Exceptions;

namespace UseCases.Handlers.Issues.Commands.UpdateIssue
{
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand>
    {
        private readonly IDbContext _dbContext;

        public UpdateIssueCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Issues.FirstOrDefaultAsync(i => i.IssueId == request.Id, cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Issue), request.Id);

            entity.Name = request.Dto.Name;
            entity.Description = request.Dto.Description;
            entity.StatusId = request.Dto.StatusId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
