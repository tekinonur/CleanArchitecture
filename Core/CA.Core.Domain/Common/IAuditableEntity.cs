using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.Core.Domain.Common
{
    public interface IAuditableEntity<T>
    {
         T CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        T UpdatedBy { get; set; }

        DateTime? UpdatedOn { get; set; }
    }
}