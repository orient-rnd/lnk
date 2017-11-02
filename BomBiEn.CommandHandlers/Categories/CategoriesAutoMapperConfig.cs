using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomBiEn.Commands.Categories;
using BomBiEn.Domain.Categories.Models;

namespace BomBiEn.CommandHandlers.Categories
{
    public class CategoriesAutoMapperConfig : Profile
    {
        public CategoriesAutoMapperConfig()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}