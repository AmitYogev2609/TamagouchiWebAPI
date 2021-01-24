using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using TamagouhciModel.Models;

namespace TamagouhciModel.Models
{
   public partial class Animal
    {
        const int ACTION_VALUE = 20;
        const int INITIAL_VALUE = 100;
        public void UptadeHealthCondition()
        {
           
            int healthConditoiSum = this.AnimalClean + this.AnimalHappy + this.AnimalHunger;
            if (healthConditoiSum > 250)
            {
                this.Healthcondition = 1;
            }
            if (healthConditoiSum <= 250 && healthConditoiSum > 100)
            {
                this.Healthcondition = 2;
            }
            if (healthConditoiSum <= 100 && healthConditoiSum > 60)
            {
                this.Healthcondition = 3;
            }
            if (healthConditoiSum <= 60)
            {
                this.Healthcondition = 4;
            }
           
        }
     
        public void Changes()
        {
            
            TimeSpan hefresh = DateTime.Now - this.AnimalBd;
            if (hefresh.Days >= 0 && hefresh.Days <= 5)
            {
                this.AnimalCycleId = 1;
            }
            if (hefresh.Days > 5 && hefresh.Days <= 12)
            {
                this.AnimalCycleId = 2;
               if(this.AnimalWegight<15)
                 this.AnimalWegight = 15+2;
               

            }
            if (hefresh.Days > 12 && hefresh.Days <= 21)
            {
                this.AnimalCycleId = 3;
                
                if (this.AnimalWegight < 40)
                 this.AnimalWegight = 40 + 2;
                
            }
            if (hefresh.Days > 21 && hefresh.Days <= 50)
            {
                this.AnimalCycleId = 4;
                if (this.AnimalWegight<= 60)
                   this.AnimalWegight= 60+2;
            }
            if (hefresh.Days > 50 && hefresh.Days < 80)
            {
               this.AnimalCycleId = 5;
            }
            if (hefresh.Days >= 80)
            {
                this.AnimalCycleId = 6;
            }
            this.AnimalWegight = this.AnimalWegight - 1;

            if (!(this.AnimalClean <= ACTION_VALUE))
            {
                this.AnimalClean = this.AnimalClean - ACTION_VALUE;
            }
            if (!(this.AnimalHappy <= ACTION_VALUE))
            {
                this.AnimalHappy = this.AnimalHappy - ACTION_VALUE;
            }
            if (!(this.AnimalHunger <= ACTION_VALUE))
            {
                this.AnimalHunger = this.AnimalHunger - ACTION_VALUE;
            }
            
        }
        public int MaxWight()
        {
            TimeSpan hefresh = DateTime.Now - this.AnimalBd;

            if (hefresh.Days >= 0 && hefresh.Days <= 5)
                return 15;
            if (hefresh.Days > 5 && hefresh.Days <= 12)
                return 40;
            if (hefresh.Days > 12 && hefresh.Days <= 21)
                return 60;
            if (hefresh.Days >= 22)
                return 100;
            return 0;
        }
        //פעולה לנקות את החיה מוסיפה את ערך הפעולה ל animalclean
        public void CleanFunction()
        {
           
            int cleanValue = this.AnimalClean;
            if (cleanValue < INITIAL_VALUE)
            {
                if (cleanValue > INITIAL_VALUE-ACTION_VALUE)
                {
                    cleanValue = INITIAL_VALUE - cleanValue;
                }
                else
                {
                    cleanValue = cleanValue+  ACTION_VALUE;
                }

            }
            this.AnimalClean = cleanValue;
            AddFunctionToList("Clean");
        }
        //פעולה להאכיל את החיה מוסיפה את ערך הפעולה ל anumalhungar
        public void FeedFunction()
        {

            int hungerValue = this.AnimalHunger;
            if (hungerValue < INITIAL_VALUE)
            {
                if (hungerValue > INITIAL_VALUE - ACTION_VALUE)
                {
                    hungerValue =hungerValue+(INITIAL_VALUE - hungerValue);
                }
                else
                {
                    hungerValue =hungerValue + ACTION_VALUE;
                }

            }
            this.AnimalHunger= hungerValue;
            if(this.MaxWight()>this.AnimalWegight)
            {
                this.AnimalWegight = this.AnimalWegight + 2;
            }
            AddFunctionToList("Feed");
        }
        //פעולה לשחק עם החיה מוסחפה את עקרך הפעולה ל animalhappy
        public void PlayFunction()
        {
            int playValue = this.AnimalHappy;
            if (playValue < INITIAL_VALUE)
            {
                if (playValue > INITIAL_VALUE - ACTION_VALUE)
                {
                   playValue = playValue+(INITIAL_VALUE - playValue);
                }
                else
                {
                    playValue = playValue + ACTION_VALUE;
                }

            }
            this.AnimalHappy = playValue;
            AddFunctionToList("Play");
        }
        public void AddFunctionToList(string functionName)
        {
            HistoryOfFunction function = new HistoryOfFunction();
            function.Animal =this;
            function.AnimalId = this.AnimalId;
            function.Functionname = functionName;
            function.FunctionDate = DateTime.Now;
            HistoryOfFunctions.Add(function);

        }
        public List<HistoryOfFunction> GetHistoryOfFunctionList()
        {

            List<HistoryOfFunction> list = new List<HistoryOfFunction>();
            foreach (HistoryOfFunction h in HistoryOfFunctions)
            {
                if (h.AnimalId == this.AnimalId)
                {
                    list.Add(h);
                }

            }
            list.OrderByDescending(a => a.FunctionDate);

            return list;

        }
    }
}
