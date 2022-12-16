namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class IssueJobDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ExecutorName { get; set; }
        public string ActionName { get; set; }
    }
}
