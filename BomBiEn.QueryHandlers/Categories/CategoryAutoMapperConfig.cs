using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Queries.Categories;
using BomBiEn.Domain.Categories.Models;
using BomBiEn.Commands.Categories;

namespace BomBiEn.QueryHandlers.Categories
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