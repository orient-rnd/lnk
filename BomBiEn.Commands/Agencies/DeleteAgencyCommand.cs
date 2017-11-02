using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Agencies
{
    public class DeleteAgencyCommand : AuditableDeleteCommandBase
    {
        public string Id { get; set; }
    }
}
