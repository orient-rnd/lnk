using LNK.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Commands.FlashCards
{
    public class CreateFlashCardCommand : AuditableCreateCommandBase
    {
        public string Id { get; set; }

        public string FaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
