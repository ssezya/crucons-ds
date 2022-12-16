using System.ComponentModel.DataAnnotations;

namespace Entities.Enums
{
    public enum JobAction
    {
        [Display(Name = "Input")]
        Input = 1,

        [Display(Name = "Opening")]
        Opening,

        [Display(Name = "Solution")]
        Solution,

        [Display(Name = "Closure")]
        Closure
    }
}
