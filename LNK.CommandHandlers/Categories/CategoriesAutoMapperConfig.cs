using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNK.Commands.Categories;
using LNK.Domain.Categories.Models;

namespace LNK.CommandHandlers.Categories
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