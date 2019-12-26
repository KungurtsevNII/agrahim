using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agrahim.Infrastructure.Entities
{
    [Table("Orders")]
    public class OrderEntity
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public uint Count { get; set; } 
    }
}