using System;
using System.ComponentModel.DataAnnotations;

namespace Agrahim.Common.ViewModels.CropsType
{
    public class UpdateCropsTypeViewModel
    {
        [Required]
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Название")]
        [MaxLength(200, ErrorMessage = "Название не должно превышать 200 символов")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Коэффициент N")]
        [Range(0.01, Double.MaxValue, ErrorMessage = "Значение не может быть меньше 0")]
        public decimal CoefficientN { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Коэффициент P")]
        [Range(0.01, Double.MaxValue, ErrorMessage = "Значение не может быть меньше 0")]
        public decimal CoefficientP { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Коэффициент K")]
        [Range(0.01, Double.MaxValue, ErrorMessage = "Значение не может быть меньше 0")]
        public decimal CoefficientK { get; set; }
        
        [Required]
        [Display(Name = "Статус")]
        public bool IsRemoved { get; set; }
    }
}