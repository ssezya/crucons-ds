using System;
using Entities.Base;

namespace Entities.Models
{
    public class Error : BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
