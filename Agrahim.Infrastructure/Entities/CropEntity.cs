using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agrahim.Infrastructure.Entities
{
    public class CropEntity
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
        public long CropsTypeId { get; set; }
        
        [ForeignKey("CropsTypeId")]
        public CropsTypeEntity CropsType { get; set; }

        [Required]
        public bool IsRemoved { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}