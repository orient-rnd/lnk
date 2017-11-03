﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Commands;

namespace LNK.Commands.Categories
{
    public class CreateCategoryCommand : AuditableCreateCommandBase
    {
        public string NameEn { get; set; }

        public string NameVn { get; set; }

        public string Description { get; set; }

        public string IdCategoryParent { get; set; }

        public int Level { get; set; }
    }
}