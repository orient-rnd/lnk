using BomBiEn.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Commands.FlashCards
{
    public class CreateFlashCardCategoryCommand : AuditableCreateCommandBase
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public bool IsFaceAShowFirst { get; set; }

        public bool IsRandom { get; set; }

        public int DisplayOrder { get; set; }
    }
}
