using System.ComponentModel.DataAnnotations;

namespace ProgrammingArticles.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        [StringLength(100, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Remember { get; set; } = false;
        public string ReturnUrl { get; set; }
    }
}
