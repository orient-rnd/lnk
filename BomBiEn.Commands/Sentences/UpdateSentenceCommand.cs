using BomBiEn.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Commands.Sentences
{
    public class UpdateSentenceCommand : CreateSentenceCommand
    {
        public string Id { get; set; }
    }
}