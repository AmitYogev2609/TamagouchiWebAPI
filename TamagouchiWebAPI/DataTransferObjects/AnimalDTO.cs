using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagouhciModel.Models;
 
namespace TamagouchiWebAPI.DataTransferObjects
{
    public class AnimalDTO
    {
        public int AnimalId { get; set; }
       
        public string AnimalName { get; set; }

        public DateTime AnimalBd { get; set; }
        public int AnimalWegight { get; set; }
        public int Healthcondition { get; set; }
        public int PlayerId { get; set; }
        public int AnimalCycleId { get; set; }
        public int AnimalHappy { get; set; }
        public int AnimalHunger { get; set; }
        public int AnimalClean { get; set; }


        public AnimalDTO(Animal a)
        {
            AnimalId = a.AnimalId;
            AnimalName = a.AnimalName;
            AnimalBd = a.AnimalBd;
            AnimalWegight = a.AnimalWegight;
            Healthcondition = a.Healthcondition;
            AnimalCycleId = a.AnimalCycleId;
            AnimalHappy = a.AnimalHappy;
            AnimalHunger = a.AnimalHunger;
            AnimalClean = a.AnimalClean;
        }
    }
}
