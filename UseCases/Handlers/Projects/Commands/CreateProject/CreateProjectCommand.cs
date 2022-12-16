using MediatR;

namespace UseCases.Handlers.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest
    {
        public string Name { get; set; }
    }
}
