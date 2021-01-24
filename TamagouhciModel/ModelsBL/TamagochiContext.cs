using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace TamagouhciModel.Models
{
     public partial class TamagochiContext
    {
        const int INITIAL_VALUE = 100;

            public Player LogIn(string email, string passwodrs)
            {
                Player p= this.Players.Where(p => p.Email == email && p.PlayerPassword == passwodrs).FirstOrDefault();
            
                return p;
            }
            public string GetHealth(Animal a)
            {
                int index = this.Animals.Where(p => p.AnimalId == a.AnimalId).FirstOrDefault().Healthcondition;
                return this.HealthAnimals.Where(p => p.HealthId == index).FirstOrDefault().Healthcondition;
            }

            public string GetLife(Animal a)
            {
                int index = this.Animals.Where(p => p.AnimalId == a.AnimalId).FirstOrDefault().AnimalCycleId;
                return this.AnimalCycles.Where(p => p.AnimalCycleId == index).FirstOrDefault().AnimalCycleName;
            }
            public Animal AddAnimal(string name, Player currentplyer)
            {
                Animal pet = new Animal();
                pet.AnimalName = name;
                pet.AnimalWegight = 5;
                pet.Healthcondition = 1;
                pet.PlayerId = currentplyer.PlayerId;
                pet.AnimalCycleId = 1;
                pet.AnimalHappy = INITIAL_VALUE;
                pet.AnimalHunger = INITIAL_VALUE;
                pet.AnimalClean = INITIAL_VALUE;
                pet.PlayerNavigation = currentplyer;
            
                try
                {
                    this.Animals.Add(pet);
                    this.SaveChanges();
                }
                catch 
                {
                    return null;
                }
                return pet;
            }
            public Player AddPlayer(string firstname, string lastname, string email, string username, string password, string gender, DateTime dDay)
            {
                Player active = new Player();
                active.PfirstName = firstname;
                active.PlastName = lastname;
                active.Email = email;
                active.UserName = username;
                active.PlayerPassword = password;
                active.PlayerGender = gender;
                active.PbirthDay = dDay;
           
                try
                { 
                    this.Players.Add(active);
                    this.SaveChanges();
                }
                catch
                {
                    return null;
                }
                return active;

            }
       
     }
       
}
