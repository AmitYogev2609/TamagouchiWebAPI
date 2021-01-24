using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;



namespace TamagouhciModel.Models
{
    public partial class Player
    {
        public void ChangeActiveAnimal(Animal c)
        {
            this.PactiveAnimal = c.AnimalId;
            this.PactiveAnimalNavigation = c;
        }
        public Animal FindPet()
        {
            Animal a = this.PactiveAnimalNavigation;
            return a;
        }
       
    }
}
