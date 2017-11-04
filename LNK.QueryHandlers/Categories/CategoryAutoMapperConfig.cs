using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Queries.Categories;
using LNK.Domain.Categories.Models;
using LNK.Commands.Categories;

namespace LNK.QueryHandlers.Categories
{
    public class CategoriesAutoMapperConfig : Profile
    {
        public CategoriesAutoMapperConfig()
        {            
            CreateMap<Category, CategoryOverview>();
            CreateMap<Category, CategoryDetails>();
            CreateMap<CategoryDetails, UpdateCategoryCommand>();
        }
    }
}