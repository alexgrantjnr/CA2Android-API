using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA2Service.Data;
using Microsoft.AspNetCore.Mvc;

namespace CA2Service.Controllers
{
    [Route("api/CA2Service")]
    [Produces("application/json")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        List<PlayerEntry> players; //List to hold players

        //Constructor generates list of players and their attributes
        /* public PlayerController()
         {
             players = new List<PlayerEntry>(); //Initialise list...and create players
             players.Add(new PlayerEntry() { FirstName = "Diego", LastName = "Maradona", Age = 52, Salary = 120000 });
             players.Add(new PlayerEntry() { FirstName = "Henrik", LastName = "Larsson", Age = 45, Salary = 110000 });
             players.Add(new PlayerEntry() { FirstName = "George", LastName = "Best", Age = 65, Salary = 150000 });
             players.Add(new PlayerEntry() { FirstName = "Jack", LastName = "Charlton", Age = 68, Salary = 65000 });
         }*/

        private readonly PlayerContext _context;

        public PlayerController(PlayerContext context)
        {
            _context = context;
        }

        // GET all players..
        [HttpGet("all")]
        public IEnumerable<PlayerEntry> GetAllEntries()
        {
            var entries = _context.PlayerEntry.OrderBy(p => p.FirstName);
            return entries;
        }

        // GET api/name/Jack  Get player by name..
        [HttpGet("name/{name}")]
        public IActionResult GetByForName(string name)
        {
            var entry = _context.PlayerEntry.Where(p => p.FirstName.ToUpper() == name.ToUpper());
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
            //return entry;
        }

        // GET api/name/Jack  Get player by name..
        [HttpGet("name/surname/{name}/{surname}")]
        public IEnumerable<PlayerEntry> GetByFullNames(string name, string surname)
        {
            var entry = _context.PlayerEntry.Where(p => p.FirstName.ToUpper() == name.ToUpper() && p.LastName.ToUpper() == surname.ToUpper());
            return entry;
        }

        // GET api/values/5
        /*[HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
