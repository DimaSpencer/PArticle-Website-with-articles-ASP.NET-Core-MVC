﻿using System.ComponentModel.DataAnnotations;

namespace ProgrammingArticles.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Invalid Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}