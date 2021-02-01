using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamagouhciModel.Models;

namespace TamagouchiWebAPI.DataTransferObjects
{
    public class FunctionDTO
    {
        public string Functionname { get; set; }
        public int AnimalId { get; set; }
        public DateTime FunctionDate { get; set; }
        public FunctionDTO() { }
        public FunctionDTO(HistoryOfFunction function)
        {
            Functionname = function.Functionname;
            AnimalId = function.AnimalId;
            FunctionDate = function.FunctionDate;
        }
    }
}
