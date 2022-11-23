﻿using System;
using System.Collections.Generic;
using Entities.Base;

namespace Entities.Models
{
    public class User : BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public string Email { get; set; }

        public ICollection<Task> Tasks { get; private set; } = new HashSet<Task>();

        public ICollection<Job> Jobs { get; private set; } = new HashSet<Job>();
    }
}
