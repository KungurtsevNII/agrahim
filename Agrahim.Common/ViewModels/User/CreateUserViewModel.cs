using System.ComponentModel.DataAnnotations;

namespace Agrahim.Common.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Не верный формат email адреса")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
         
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}