namespace SugdAgro.DTOs.Articles
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? Author { get; set; }
        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ViewCount { get; set; }
    }
}
