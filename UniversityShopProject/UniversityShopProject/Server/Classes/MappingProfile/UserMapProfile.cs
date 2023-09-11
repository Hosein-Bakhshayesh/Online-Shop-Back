using AutoMapper;
using UniversityShopProject.Shared.ViewModels.Order;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProject.Shared.ViewModels.WishList;
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
            CreateMap<User, UserCreateViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<UserCreateViewModel, User>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<WishList, WishListViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<WishListViewModel, WishList>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Order, OrderViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<OrderViewModel, Order>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<OrderItem, OrderItemViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<OrderItemViewModel, OrderItem>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Address, AddressesViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<AddressesViewModel, Address>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<Cart, CartViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CartViewModel, Cart>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CartItem, CartItemViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CartItemViewModel, CartItem>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
