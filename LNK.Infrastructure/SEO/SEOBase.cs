﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Infrastructure.SEO
{
    public interface SEOBase
    {
        string SEODescription { get; set; }

        string SEOKeyWords { get; set; }

        string SEOTitle { get; set; }
    }
}