namespace UseCases.Handlers.Issues.Queries.GetIssuesList
{
    public class IssueDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProjectName { get; set; }
        public string ReporterName { get; set; }
        public string StatusName { get; set; }
        public string ExecutorName { get; set; }
    }
}
