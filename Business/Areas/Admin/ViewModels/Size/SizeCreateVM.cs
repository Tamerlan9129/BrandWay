﻿using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Size
{
    public class SizeCreateVM
    {
        [Required]
        public string Title { get; set; }
    }
}
