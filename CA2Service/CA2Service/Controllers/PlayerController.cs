﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/
using CA2Service.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
//using Microsoft.AspNetCore.Mvc;

/*
 Developers:
 Bren Dempsey & Alex Grant
 4th Year Software Students
 EAD2 - CA2[Elapsed]
 Out: 28/02/2019
 Due: 31/03/2019
*/

namespace CA2Service.Controllers
{
   
    [Route("api/CA2Service")]
    [Produces("application/json")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        // List<PlayerEntry> players; //List to hold players
        //*** TEST DATA for Swagger ***
        //Constructor generates list of players and their attributes
        /* public PlayerController()
         {
             players = new List<PlayerEntry>(); //Initialise list...and create players
             players.Add(new PlayerEntry() { FirstName = "Diego", LastName = "Maradona", Age = 52, Salary = 120000 });
             players.Add(new PlayerEntry() { FirstName = "Henrik", LastName = "Larsson", Age = 45, Salary = 110000 });
             players.Add(new PlayerEntry() { FirstName = "George", LastName = "Best", Age = 65, Salary = 150000 });
             players.Add(new PlayerEntry() { FirstName = "Jack", LastName = "Charlton", Age = 68, Salary = 65000 });
         }*/


        //Read-only attribute to specify the DBContext Connection
        private readonly PlayerContext _connection; 

        //Constructor sets the context
        public PlayerController(PlayerContext context)
        {
            _connection = context;
        }

        // GET all players..
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]      
        [HttpGet("all")]
        public IActionResult GetAllEntries()
        {
            var entries = _connection.Players.OrderBy(p => p.FirstName); //Order by name alphabetically
            if (entries == null)
            {
                return NotFound(); //Return err 400's
            }
            return Ok(entries); //Return OK 200's
        }

        // Get player by firstname..
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]     
        [HttpGet("name/{name}")]
        public IActionResult GetByForName(string name)
        {
            var entry = _connection.Players.Where(p => p.FirstName.ToUpper() == name.ToUpper()); //Camel casing
            if (entry == null)
            {
                return NotFound(); //Return err 400's
            }
            return Ok(entry); //Return OK 200's
        }

        // Get player by full name..
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]       
        [HttpGet("name/surname/{name}/{surname}")]
        public IActionResult GetByFullNames(string name, string surname)
        {
            var entry = _connection.Players.Where(p => p.FirstName.ToUpper() 
            == name.ToUpper() && p.LastName.ToUpper() == surname.ToUpper()); //Camel casing
            if (entry == null)
            {
                return NotFound(); //Return err 400's
            }
            return Ok(entry); //Return OK 200's
        }       
    }
}
