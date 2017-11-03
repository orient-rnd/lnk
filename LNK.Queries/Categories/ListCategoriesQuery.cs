﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Categories
{
    public class ListCategoriesQuery : ListQueryBase
    {
        public string CategoryName { get; set; }

        public string CategoryParent { get; set; }
    }
}