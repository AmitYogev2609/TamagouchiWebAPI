using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagouhciModel.Models
{
    [Table("AnimalCycle")]
    public partial class AnimalCycle
    {
        public AnimalCycle()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int AnimalCycleId { get; set; }
        [Required]
        [StringLength(20)]
        public string AnimalCycleName { get; set; }

        [InverseProperty(nameof(Animal.AnimalCycle))]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
