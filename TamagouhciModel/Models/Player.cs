using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagouhciModel.Models
{
    [Index(nameof(Email), Name = "UniqueEmail", IsUnique = true)]
    [Index(nameof(UserName), Name = "UniqueUserName", IsUnique = true)]
    public partial class Player
    {
        public Player()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string PlayerPassword { get; set; }
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }
        [Column("PActiveAnimal")]
        public int? PactiveAnimal { get; set; }
        [StringLength(10)]
        public string PlayerGender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PbirthDay { get; set; }
        [Required]
        [StringLength(15)]
        public string PfirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string PlastName { get; set; }

        [ForeignKey(nameof(PactiveAnimal))]
        [InverseProperty(nameof(Animal.PlayerNavigation))]
        public virtual Animal PactiveAnimalNavigation { get; set; }
        [InverseProperty(nameof(Animal.Player))]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
