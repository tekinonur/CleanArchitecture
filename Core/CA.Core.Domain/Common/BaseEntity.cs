using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA.Core.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public virtual T ID { get; set; }
    }
}