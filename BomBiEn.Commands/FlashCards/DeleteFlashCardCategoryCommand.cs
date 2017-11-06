using BomBiEn.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BomBiEn.Commands.FlashCards
{
    public class DeleteFlashcardCategoryCommand : AuditableDeleteCommandBase
    {
        public string Id { get; set; }
    }
}
