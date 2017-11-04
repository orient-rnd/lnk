using LNK.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Commands.FlashCards
{
    public class DeleteFlashCardCategoryCommand : AuditableDeleteCommandBase
    {
        public string Id { get; set; }
    }
}
