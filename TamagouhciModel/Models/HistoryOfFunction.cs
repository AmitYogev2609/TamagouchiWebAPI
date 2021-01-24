using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagouhciModel.Models
{
    [Index(nameof(FunctionDate), Name = "FunctionDate")]
    public partial class HistoryOfFunction
    {
        [Required]
        [StringLength(255)]
        public string Functionname { get; set; }
        [Key]
        [Column("AnimalID")]
        public int AnimalId { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime FunctionDate { get; set; }

        [ForeignKey(nameof(AnimalId))]
        [InverseProperty("HistoryOfFunctions")]
        public virtual Animal Animal { get; set; }
    }
}
