﻿using System;

namespace Entities.Base
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAtUtc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAtUtc { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
