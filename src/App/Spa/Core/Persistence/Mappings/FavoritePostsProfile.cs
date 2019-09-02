using AdisBlog.Core.Persistence.Dtos;
using AdisBlog.Models;
using AutoMapper;

namespace AdisBlog.Core.Persistence.Mappings
{
    public class FavoritePostsProfile : Profile
    {
        public FavoritePostsProfile()
        {
            CreateMap<Post, FavoritePostDto>();
        }
    }
}