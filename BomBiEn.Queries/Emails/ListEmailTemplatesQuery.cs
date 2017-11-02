using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.Queries.Emails
{
    public class ListEmailTemplatesQuery : ListQueryBase
    {
        public string[] EmailTemplateCategoryIds { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string LanguageCode { get; set; }
    }
}