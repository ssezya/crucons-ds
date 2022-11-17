using System;
using Entities.Base;

namespace Entities.Models
{
    public class User : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
    }
}
