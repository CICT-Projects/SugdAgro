using System;
using System.ComponentModel.DataAnnotations;

namespace SugdAgro.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }   

        [Required(ErrorMessage = "Заголовок обязателен для заполнения")]
        [StringLength(200, ErrorMessage = "Заголовок не может превышать 200 символов")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Контент обязателен для заполнения")]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Автор обязателен для заполнения")]
        [RegularExpression(@"^[a-z0-9-]+$", 
            ErrorMessage = "Слаг должен состоять из строчных латинских букв, цифр и дефисов")]
        public string Slug { get; set; } = string.Empty;
    }
}
