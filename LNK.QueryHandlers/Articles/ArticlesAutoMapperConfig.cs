using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Queries.Articles;
using LNK.Domain.Articles.Models;
using LNK.Commands.Articles;

namespace LNK.QueryHandlers.Articles
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