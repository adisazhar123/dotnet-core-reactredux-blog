using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AdisBlog.Models;
using Microsoft.AspNetCore.Http;

namespace AdisBlog.Core.Persistence.Requests
{
    public class CreatePost
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

        public IFormFile CoverImage { get; set; }
        public List<SelectTag> Tags { get; set; } 
    }

    public class SelectTag
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
}