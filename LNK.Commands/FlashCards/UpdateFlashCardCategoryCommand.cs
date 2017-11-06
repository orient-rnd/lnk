﻿using LNK.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Commands.FlashCards
{
    public class UpdateFlashCardCategoryCommand : AuditableUpdateCommandBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public bool IsFaceAShowFirst { get; set; }

        public bool IsRandom { get; set; }

        public int DisplayOrder { get; set; }       
    }
}