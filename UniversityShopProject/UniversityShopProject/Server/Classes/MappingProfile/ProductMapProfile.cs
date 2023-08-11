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

            CreateMap<ProductInfoViewModel, Product>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Product, ProductInfoViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<ProductAttribute, ProductAttributeViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ProductAttributeViewModel, ProductAttribute>().IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<ProductImage, ProductImagesViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<ProductImagesViewModel, ProductImage>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
