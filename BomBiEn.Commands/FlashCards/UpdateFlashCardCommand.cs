using BomBiEn.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Commands.FlashCards
{
    public class UpdateFlashCardCommand : AuditableUpdateCommandBase
    {
        public string Id { get; set; }

        public string FaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
