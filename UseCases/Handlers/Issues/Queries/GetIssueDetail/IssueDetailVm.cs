using System;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class IssueDetailVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int JobsCount() => Jobs.Count();
        public ICollection<IssueJobDto> Jobs { get; set; }
    }
}
