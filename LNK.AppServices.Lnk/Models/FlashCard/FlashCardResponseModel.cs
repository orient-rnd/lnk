using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Lnk.Models.FlashCard
{
    public class FlashCardResponseModel
    {
        public string Id { get; set; }

        public string FaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public string FlashCardCategoryName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
