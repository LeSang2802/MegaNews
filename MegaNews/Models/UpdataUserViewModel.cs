﻿using System.ComponentModel.DataAnnotations;

namespace MegaNews.Models
{
    public class UpdataUserViewModel
    {
        [Required]
        public required string UserName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public IFormFile? fileInput { get; set; }
    }
}
