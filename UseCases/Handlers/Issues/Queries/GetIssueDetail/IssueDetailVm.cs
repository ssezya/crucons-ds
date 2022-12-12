using System;
using System.Collections.Generic;

namespace UseCases.Handlers.Issues.Queries.GetIssueDetail
{
    public class IssueDetailVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public int JobsCount { get; set; }
        public ICollection<IssueJobDto> Jobs { get; set; }
    }
}
