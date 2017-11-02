﻿using BomBiEn.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Queries.Sentences
{
    public class GetAllSentencesQuery : QueryBase
    {
        public string Id { get; set; }

        public string IdCategory { get; set; }
    }
}
