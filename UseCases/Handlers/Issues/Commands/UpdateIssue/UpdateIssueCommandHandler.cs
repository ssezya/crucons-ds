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
        private readonly IApplicationDbContext _dbContext;

        public UpdateIssueCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Issues.FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Issue), request.Id);

            entity.Title = request.Dto.Title;
            entity.Description = request.Dto.Description;
            entity.ProjectId = request.Dto.ProjectId;
            entity.ReporterId = request.Dto.ReporterId;
            entity.ExecutorId = request.Dto.ExecutorId;
            entity.StatusId = request.Dto.StatusId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
