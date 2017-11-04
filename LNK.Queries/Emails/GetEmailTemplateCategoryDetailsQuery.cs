using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Emails
{
    public class GetEmailTemplateCategoryDetailsQuery : QueryBase
    {
        public string Id { get; set; }

        public string Code { get; set; }
    }
}