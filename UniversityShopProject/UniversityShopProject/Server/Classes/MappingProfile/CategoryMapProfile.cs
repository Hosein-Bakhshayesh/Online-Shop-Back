using AutoMapper;
using UniversityShopProject.Shared.ViewModels;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProjectModels.Models;

namespace UniversityShopProject.Server.Classes.MappingProfile
{
    public class CategoryMapProfile:Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CategoryViewModel, Category>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
