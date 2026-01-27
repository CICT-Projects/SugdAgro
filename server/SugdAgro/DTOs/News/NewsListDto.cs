namespace SugdAgro.DTOs.News;

public class NewsListDto
{
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Slug { get; set; } = string.Empty;
    
    public string? ImageUrl { get; set; }
    
    public string? CategoryName { get; set; }
    
    public DateTime CreatedAt { get; set; }
}