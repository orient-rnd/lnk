﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.Queries.Emails
{
    public class GetEmailTemplateCategoryDetailsQuery : QueryBase
    {
        public string Id { get; set; }

        public string Code { get; set; }
    }
}