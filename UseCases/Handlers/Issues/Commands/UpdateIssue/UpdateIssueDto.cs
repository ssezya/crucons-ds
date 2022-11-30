namespace UseCases.Handlers.Issues.Commands.UpdateIssue
{
    public class UpdateIssueDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
