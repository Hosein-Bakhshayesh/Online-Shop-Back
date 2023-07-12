using UniversityShopProject.Shared.ViewModels.Admin;
using UniversityShopProjectModels.Models;
using AutoMapper;
using UniversityShopProject.Shared.ViewModels.Product;

namespace UniversityShopProject.Server.Classes.MappingProfile
{
    public class ProductMapProfile:Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ProductViewModel, Product>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
