using System.Collections.Generic;
using Entities.Base;

namespace Entities.Models
{
    public class Project : AuditableEntity
    {
        public Project()
        {
            Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Issue> Issues { get; private set; }
    }
}
