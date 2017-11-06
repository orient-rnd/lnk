using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Sentences;
using LNK.Domain.Sentences.Models;

namespace LNK.CommandHandlers.Sentences
{
    public class SentencesAutoMapperConfig : Profile
    {
        public SentencesAutoMapperConfig()
        {
            CreateMap<CreateSentenceCommand, Sentence>();
            CreateMap<UpdateSentenceCommand, Sentence>();
            CreateMap<DictionaryCommand, Dictionary>();
        }
    }
}