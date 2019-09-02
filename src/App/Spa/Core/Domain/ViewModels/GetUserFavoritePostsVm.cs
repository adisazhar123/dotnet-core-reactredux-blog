using System;
using System.Collections.Generic;
using AdisBlog.Core.Persistence.Dtos;

namespace AdisBlog.Core.Domain.ViewModels
{
    public class GetUserFavoritePostsVm
    {
        public IEnumerable<FavoritePostDto> Posts { get; set; }
    }
}