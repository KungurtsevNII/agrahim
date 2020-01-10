using System.ComponentModel.DataAnnotations;

namespace Agrahim.Common.ViewModels
{
    public class UpdateCropsTypeViewModel
    {
        [Required]
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Название")]
        [MaxLength(200, ErrorMessage = "Название не должно превышать 200 символов")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Статус")]
        public bool IsRemoved { get; set; }
    }
}