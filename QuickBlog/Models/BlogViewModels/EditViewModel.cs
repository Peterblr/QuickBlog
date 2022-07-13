﻿using QuickBlog.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace QuickBlog.Models.BlogViewModels
{
    public class EditViewModel
    {
        [Display(Name = "Header Image")]
        public IFormFile HeaderImage { get; set; }
        public Blog Blog { get; set; }
    }
}
