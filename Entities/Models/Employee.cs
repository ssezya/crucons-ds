using System.Collections.Generic;

namespace Entities.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Issue> CreatedIssues { get; private set; } = new HashSet<Issue>();
        public ICollection<Issue> LastModifiedIssues { get; private set; } = new HashSet<Issue>();
        public ICollection<Job> CreatedJobs { get; private set; } = new HashSet<Job>();
        public ICollection<Job> LastModifiedJobs { get; private set; } = new HashSet<Job>();
    }
}
