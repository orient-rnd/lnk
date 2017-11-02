using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.Articles;
using BomBiEn.Domain.Articles.Models;

namespace BomBiEn.CommandHandlers.Articles
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