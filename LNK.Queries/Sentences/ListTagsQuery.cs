using LNK.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace LNK.Queries.Sentences
{
    public class ListTagsQuery : QueryBase
    {
        public List<string> Tags { get; set; } = new List<string>();
    }
}
