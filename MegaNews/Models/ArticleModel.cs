using System;
using System.ComponentModel.DataAnnotations;

namespace MegaNews.Models
{
    public class ArticleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        [StringLength(500)]
        public string? Summary { get; set; }

        [StringLength(100)]
        public string? Category { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public required string Author { get; set; }
    }
}
