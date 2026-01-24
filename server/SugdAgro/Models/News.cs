using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SugdAgro.Models
{
    public class News : BaseEntity
    {
        public string TitleTg { get; set; } = string.Empty;
        public string TitleRu { get; set; } = string.Empty;
        public string ContentTg { get; set; } = string.Empty;
        public string ContentRu { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public int ViewCount { get; set; }
        
        public Category? Category { get; set; }
    }
}