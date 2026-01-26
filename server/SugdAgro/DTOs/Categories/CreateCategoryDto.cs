using System.ComponentModel.DataAnnotations;

namespace SugdAgro.DTOs.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string NameTg { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string NameRu { get; set; } = string.Empty;

        public string? Slug { get; set; }
    }
}

