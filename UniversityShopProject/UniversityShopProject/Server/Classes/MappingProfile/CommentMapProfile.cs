using AutoMapper;
using UniversityShopProject.Shared.ViewModels.Admin;
using UniversityShopProject.Shared.ViewModels.Comment;
using UniversityShopProjectModels.Models;

namespace UniversityShopProject.Server.Classes.MappingProfile
{
    public class CommentMapProfile:Profile
    {
        public CommentMapProfile()
        {
            CreateMap<Comment, CommentViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CommentViewModel, Comment>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
