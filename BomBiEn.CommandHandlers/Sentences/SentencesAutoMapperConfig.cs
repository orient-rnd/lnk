using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.Sentences;
using BomBiEn.Domain.Sentences.Models;

namespace BomBiEn.CommandHandlers.Sentences
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