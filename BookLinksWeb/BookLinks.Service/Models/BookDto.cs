﻿
using BookLinks.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace BookLinks.Service.Models
{
    public class BookDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime Released { get; set; }

        public int Rating { get; set; }

        public string ImageContent { get; set; }

        public string OriginalFileName { get; set; }

        public List<Link> Links { get; set; }
    }
}