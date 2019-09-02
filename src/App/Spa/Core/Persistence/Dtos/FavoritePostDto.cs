using System;

namespace AdisBlog.Core.Persistence.Dtos
{
    public class FavoritePostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Username { get; set; }
    }
}