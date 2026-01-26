
namespace SugdAgro.Models
{
    public class Article : BaseEntity
    {
        public string TitleTg { get; set; } = string.Empty;
        public string TitleRu { get; set; } = string.Empty;
        public string ContentTg { get; set; } = string.Empty;
        public string ContentRu { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? Author { get; set; }
        public int? CategoryId { get; set; }
        public int ViewCount { get; set; }

        // Навигационное свойство к категории
        public Category? Category { get; set; }
    }
}