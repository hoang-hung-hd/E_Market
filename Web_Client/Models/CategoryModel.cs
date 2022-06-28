﻿using System.ComponentModel.DataAnnotations;

namespace Web_Client.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3 to 50 characters")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Manufacturer must be 3 to 100 characters")]
        public string Manufacturer { set; get; }
    }
}
