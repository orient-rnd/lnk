using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Domain
{
    public abstract class FullAuditableEntityBase : AuditableEntityBase
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string DeletedBy { get; set; }
    }
}