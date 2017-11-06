using LNK.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Commands.Sentences
{
    public class UpdateSentenceCommand : CreateSentenceCommand
    {
        public string Id { get; set; }
    }
}