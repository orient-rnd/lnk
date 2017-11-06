﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Lnk.Models.FlashCard
{
    public class CreateFlashCardModel
    {
        public string Id { get; set; }

        public string FaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public string FlashCardCategoryName { get; set; }

        public int DisplayOrder { get; set; }

        public string UserEmail { get; set; }

        public int ViewNumber { get; set; }

    }
}
