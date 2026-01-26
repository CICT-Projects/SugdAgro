
namespace SugdAgro.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string NameTg { get; set; } = string.Empty;
        public string NameRu { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public ICollection<News> News { get; set; } = new List<News>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}