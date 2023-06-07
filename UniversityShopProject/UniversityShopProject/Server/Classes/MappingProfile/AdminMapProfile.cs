using UniversityShopProject.Shared.ViewModels.Admin;
using UniversityShopProjectModels.Models;
using AutoMapper;

namespace UniversityShopProject.Server.Classes.MappingProfile
{
    public class AdminMapProfile:Profile
    {
        public AdminMapProfile()
        {
            CreateMap<Admin, AdminListViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<AdminListViewModel, Admin>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Admin, AdminInfoViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<AdminInfoViewModel, Admin>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Admin, AdminCreateViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<AdminCreateViewModel, Admin>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
