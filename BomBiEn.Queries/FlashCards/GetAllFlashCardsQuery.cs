﻿using BomBiEn.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Queries.FlashCards
{
    public class GetAllFlashCardsQuery : QueryBase
    {
        public string IdCategory { get; set; }
    }
}
