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
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(500)]
        public string? Summary { get; set; }  // Giới thiệu ngắn gọn

        [StringLength(100)]
        public string? Category { get; set; } // Ví dụ: Thời Sự, Thể Thao, Giải Trí...

        [StringLength(255)]
        public string? ImageUrl { get; set; } // Đường dẫn ảnh minh họa

        [DataType(DataType.DateTime)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public string Author { get; set; } // Tác giả bài viết
    }
}
