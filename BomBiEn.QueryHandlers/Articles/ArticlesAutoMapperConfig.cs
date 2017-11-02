using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Queries.Articles;
using BomBiEn.Domain.Articles.Models;
using BomBiEn.Commands.Articles;

namespace BomBiEn.QueryHandlers.Articles
{
    public class ArticlesAutoMapperConfig : Profile
    {
        public ArticlesAutoMapperConfig()
        {
            CreateMap<Article, ArticleOverview>();
            CreateMap<Article, ArticleDetails>();
            CreateMap<ArticleDetails, UpdateArticleCommand>();
        }
    }
}