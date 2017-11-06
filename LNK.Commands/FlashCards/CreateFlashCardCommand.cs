﻿using LNK.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LNK.Commands.FlashCards
{
    public class CreateFlashCardCommand : AuditableCreateCommandBase
    {
        public string FaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public string FlashCardCategoryName { get; set; }

        public string UserEmail { get; set; }

        public int DisplayOrder { get; set; }

        public int ViewNumber { get; set; }
    }
}