﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            CreatedOn = DateTime.Now;
            IsDeleted = false;
        }
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? ModifyBy { get; set; }
        public virtual DateTime? ModifyOn { get; set; }
    }
}
