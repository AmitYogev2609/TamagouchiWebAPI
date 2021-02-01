using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TamagouhciModel.Models;
using TamagouchiWebAPI.DataTransferObjects;

namespace TamagouchiWebAPI.Controllers
{
    [Route("Tamagouchi")]
    [ApiController]
    public class Tamagouchi : Controller
    {
        TamagochiContext context;
        public Tamagouchi(TamagochiContext context)
        {
            this.context = context;
        }


        [Route("Login")]
        [HttpGet]
        public PlayerDTO Login([FromQuery] string email, [FromQuery] string pass)
        {
            Player p = context.LogIn(email, pass);

            //Check user name and password
            if (p != null)
            {
                PlayerDTO pDTO = new PlayerDTO(p);

                HttpContext.Session.SetObject("player", pDTO);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        [Route("GetAnimals")]
        [HttpGet]
        public AnimalDTO GetAnimals()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.PlayerId == pDto.PlayerId).FirstOrDefault();
                 
                if (p != null&&p.PactiveAnimalNavigation!=null)
                {
                    AnimalDTO activePet = new AnimalDTO(p.PactiveAnimalNavigation);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                    return activePet;
                }
                
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            return null;
        }
        [Route("Changes")]
        [HttpGet]
        public AnimalDTO Changes()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.PlayerId == pDto.PlayerId).FirstOrDefault();

                if (p != null)
                {
                    context.changes(p.PactiveAnimalNavigation);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return new AnimalDTO(p.PactiveAnimalNavigation);

                }
                
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            return null;
        }
        [Route("SignUp")]
        [HttpPost]
        public PlayerDTO SignUp([FromBody] PlayerDTO a)
        {
            DateTime d = new DateTime(a.PbirthDay.Value.Year, a.PbirthDay.Value.Month, a.PbirthDay.Value.Day);
            Player p =  context.AddPlayer(a.PfirstName, a.PlastName, a.Email,a.UserName,a.PlayerPassword , a.PlayerPassword, d);
            if (p != null)
            {
                PlayerDTO pDTO = new PlayerDTO(p);
                HttpContext.Session.SetObject("player", pDTO);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("AddPet")]
        [HttpGet]
        public AnimalDTO AddPet([FromQuery] string animalName)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.PlayerId == pDto.PlayerId).FirstOrDefault();
                Animal createPet = context.AddAnimal(animalName,p);
                
                if (createPet != null)
                {
                  
                   AnimalDTO aniDTO= new AnimalDTO(p.PactiveAnimalNavigation);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                    return aniDTO;

                }
                
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            return null;
        }
        [Route("DoAction")]
        [HttpGet]
        public AnimalDTO DoAction([FromQuery] int i)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.PlayerId == pDto.PlayerId).FirstOrDefault();
                Animal pet = p.PactiveAnimalNavigation;

                if (pet != null)
                {
                    context.DoAction(pet, i);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return new AnimalDTO(pet);
                }
              
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            return null;
        }
        [Route("GetAction")]
        [HttpGet]
        public List<FunctionDTO> GetFunctions()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.PlayerId == pDto.PlayerId).FirstOrDefault();
                Animal pet = p.PactiveAnimalNavigation;

                if (pet != null)
                {
                    List<HistoryOfFunction> functions = pet.GetHistoryOfFunctionList();
                    List<FunctionDTO> functionDTOs = new List<FunctionDTO>();
                    foreach (HistoryOfFunction item in functions)
                    {
                        functionDTOs.Add(new FunctionDTO(item));
                    }
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return functionDTOs;
                }

            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            return null;
        }
    }
}
   

