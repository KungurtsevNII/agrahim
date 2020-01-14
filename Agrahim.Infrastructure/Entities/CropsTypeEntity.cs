using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Agrahim.Infrastructure.Entities
{
    [Table("CropsTypes")]
    public class CropsTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string NormalizedName { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CoefficientN { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CoefficientP { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CoefficientK { get; set; }

        [Required]
        public bool IsRemoved { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}