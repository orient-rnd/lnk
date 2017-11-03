using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Agencies
{
    public class UpdateAgencyCommand : AuditableUpdateCommandBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }
    }
}