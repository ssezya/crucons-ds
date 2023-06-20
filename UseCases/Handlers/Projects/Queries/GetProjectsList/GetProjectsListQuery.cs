using MediatR;

namespace UseCases.Handlers.Projects.Queries.GetProjectsList
{
    public class GetProjectsListQuery : IRequest<ProjectsListVm> { }
}
