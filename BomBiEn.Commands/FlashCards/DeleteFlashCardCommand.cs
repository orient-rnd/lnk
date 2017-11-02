using BomBiEn.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Commands.FlashCards
{
    public class DeleteFlashCardCommand : AuditableDeleteCommandBase
    {
        public string Id { get; set; }
    }
}
