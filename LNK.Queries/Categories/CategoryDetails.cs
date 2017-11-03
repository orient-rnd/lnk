using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Queries.Categories
{
    public class CategoryDetails
    {
        public string Id { get; set; }

        public string NameEn { get; set; }

        public string NameVn { get; set; }

        public string Description { get; set; }

        public string IdCategoryParent { get; set; }
    }
}
