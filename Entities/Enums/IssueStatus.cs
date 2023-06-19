using System.ComponentModel.DataAnnotations;

namespace Entities.Enums
{
    public enum IssueStatus
    {
        [Display(Name = "New")]
        New = 1,

        [Display(Name = "Open")]
        Open,

        [Display(Name = "In progress")]
        InProgress,

        [Display(Name = "Solved")]
        Solved,

        [Display(Name = "To be tested")]
        ToBeTested,

        [Display(Name = "Closed")]
        Closed
    }
}
