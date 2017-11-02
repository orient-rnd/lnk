using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Articles
{
    public class CreateArticleCommand : AuditableCreateCommandBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string LinkMedia { get; set; }

        public string CopyFrom { get; set; }

        public string Author { get; set; }

        public string CategoryId { get; set; }
    }
}
