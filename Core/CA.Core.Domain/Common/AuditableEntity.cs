using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.Core.Domain.Common
{
    public abstract class AuditableEntity<T> : BaseEntity<T>, IAuditableEntity<T>
    {
        public virtual T CreatedBy { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual T UpdatedBy { get; set; }

        public virtual DateTime? UpdatedOn { get; set; }
    }
}