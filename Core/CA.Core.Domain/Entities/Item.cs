using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Core.Domain.Common;

namespace CA.Core.Domain.Entities
{
    public class Item : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
} 