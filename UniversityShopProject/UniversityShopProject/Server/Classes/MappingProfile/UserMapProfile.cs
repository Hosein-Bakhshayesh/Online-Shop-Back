using AutoMapper;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProjectModels.Models;

namespace UniversityShopProject.Server.Classes.MappingProfile
{
    public class UserMapProfile:Profile
    {
        public UserMapProfile()
        {
            CreateMap<User, UserListViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<UserListViewModel, User>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<User, UserInfoViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<UserInfoViewModel, User>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
