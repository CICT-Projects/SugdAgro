using System.ComponentModel.DataAnnotations;

namespace SugdAgro.DTOs.Articles
{
    public class CreateArticleDto
    {
        [Required]
        [MaxLength(200)]
        public string TitleTg { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string TitleRu { get; set; } = string.Empty;

        [Required]
        public string ContentTg { get; set; } = string.Empty;

        [Required]
        public string ContentRu { get; set; } = string.Empty;

        [Required]
        public string Slug { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string? Author { get; set; }

        public int? CategoryId { get; set; }
    }
}

