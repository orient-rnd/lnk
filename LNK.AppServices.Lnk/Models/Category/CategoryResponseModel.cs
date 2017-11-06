using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Lnk.Models.Category
{
    public class CategoryResponseModel
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
