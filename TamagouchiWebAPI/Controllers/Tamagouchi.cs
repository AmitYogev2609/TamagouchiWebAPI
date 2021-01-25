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


        [Route("SignUp")]
        [HttpPost]
        public PlayerDTO SignUp([FromBody] string email, [FromBody] string pass, [FromBody] string fname, [FromBody] string lname, [FromBody] string gender, [FromBody] string uname, [FromBody] DateTime bdate)
        {
            Player p = context.AddPlayer(fname, lname, email, uname, pass, gender, bdate);
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
        [HttpPost]
        public AnimalDTO AddPet([FromBody] string animalName)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.Players.Where(pp => pp.PlayerId == pDto.PlayerId).FirstOrDefault();
                Animal createPet = context.AddAnimal(animalName,p;
                if(createPet != null)
                {
                AnimalDTO aniDTO= new AnimalDTO(createPet);
                }
            }
        }
    }
}
