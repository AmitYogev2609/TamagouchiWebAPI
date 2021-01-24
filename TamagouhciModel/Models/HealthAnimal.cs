using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagouhciModel.Models
{
    [Table("healthAnimal")]
    public partial class HealthAnimal
    {
        public HealthAnimal()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int HealthId { get; set; }
        [Required]
        [Column("healthcondition")]
        [StringLength(20)]
        public string Healthcondition { get; set; }

        [InverseProperty(nameof(Animal.HealthconditionNavigation))]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
