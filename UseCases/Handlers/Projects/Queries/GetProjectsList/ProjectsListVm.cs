using System.Collections.Generic;

namespace UseCases.Handlers.Projects.Queries.GetProjectsList
{
    public class ProjectsListVm
    {
        public ICollection<ProjectDto> Projects { get; set; }
    }
}
