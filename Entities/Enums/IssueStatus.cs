using System.ComponentModel.DataAnnotations;

namespace Entities.Enums
{
    public enum IssueStatus
    {
        [Display(Name = "New")]
        New = 1,

        [Display(Name = "Open")]
        Open,

        [Display(Name = "Solved")]
        Solved,

        [Display(Name = "Closed")]
        Closed
    }
}
