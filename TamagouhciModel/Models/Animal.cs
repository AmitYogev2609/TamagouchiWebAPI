using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagouhciModel.Models
{
    public partial class Animal
    {
        public Animal()
        {
            HistoryOfFunctions = new HashSet<HistoryOfFunction>();
        }

        [Key]
        [Column("AnimalID")]
        public int AnimalId { get; set; }
        [Required]
        [StringLength(15)]
        public string AnimalName { get; set; }
        [Column("AnimalBD", TypeName = "datetime")]
        public DateTime AnimalBd { get; set; }
        public int AnimalWegight { get; set; }
        [Column("healthcondition")]
        public int Healthcondition { get; set; }
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        public int AnimalCycleId { get; set; }
        public int AnimalHappy { get; set; }
        public int AnimalHunger { get; set; }
        public int AnimalClean { get; set; }

        [ForeignKey(nameof(AnimalCycleId))]
        [InverseProperty("Animals")]
        public virtual AnimalCycle AnimalCycle { get; set; }
        [ForeignKey(nameof(Healthcondition))]
        [InverseProperty(nameof(HealthAnimal.Animals))]
        public virtual HealthAnimal HealthconditionNavigation { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Animals")]
        public virtual Player Player { get; set; }
        [InverseProperty("PactiveAnimalNavigation")]
        public virtual Player PlayerNavigation { get; set; }
        [InverseProperty(nameof(HistoryOfFunction.Animal))]
        public virtual ICollection<HistoryOfFunction> HistoryOfFunctions { get; set; }
    }
}
