using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Articles;
using LNK.Domain.Articles.Models;

namespace LNK.CommandHandlers.Articles
{
    public class ArticlesAutoMapperConfig : Profile
    {
        public ArticlesAutoMapperConfig()
        {
            CreateMap<CreateArticleCommand, Article>();
            CreateMap<UpdateArticleCommand, Article>();
        }
    }
}