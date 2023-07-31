using System.ComponentModel.DataAnnotations;

namespace Test_IOMundo.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "User name")]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
