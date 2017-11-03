using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Queries;

namespace LNK.Queries.Sentences
{
    public class GetListSentencesBasicQuery : QueryBase
    {
        public string CategoryId { get; set; }
    }
}