using System.ComponentModel.DataAnnotations;

namespace Agrahim.Common.ViewModels.Crops
{
    public class CreateCropViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Название")]
        [MaxLength(200, ErrorMessage = "Название не должно превышать 200 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public long CropsTypeId { get; set; }
    }
}