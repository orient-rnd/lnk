using System;

namespace BomBiEn.Infrastructure.Domain
{
    public interface IAuditableEntityBase
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}