﻿using System.Collections.Generic;

namespace Entities.Models
{
    public class Employee
    {
        public Employee()
        {
            ReporterOfIssues = new HashSet<Issue>();
            ExecutorOfIssues = new HashSet<Issue>();
            WriterOfNotes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Issue> ReporterOfIssues { get; private set; }
        public ICollection<Issue> ExecutorOfIssues { get; private set; }
        public ICollection<Note> WriterOfNotes { get; private set; }
    }
}
