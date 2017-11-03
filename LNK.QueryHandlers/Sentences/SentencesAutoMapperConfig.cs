using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Queries.Sentences;
using LNK.Domain.Sentences.Models;
using LNK.Commands.Sentences;

namespace LNK.QueryHandlers.Sentences
{
    public class SentencesAutoMapperConfig : Profile
    {
        public SentencesAutoMapperConfig()
        {
            CreateMap<Sentence, SentenceOverview>();
            CreateMap<Sentence, SentenceBasic>();
            CreateMap<Sentence, SentenceDetails>();
            CreateMap<SentenceDetails, UpdateSentenceCommand>();
            CreateMap<Dictionary, DictionaryQuery>();
        }
    }
}