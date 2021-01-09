using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc; //Modern View Controller - use .NET to serve HTML pages
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //specify api/users to get to this controller
    public class UsersController : ControllerBase //Derive from ControllerBase
    {
        private readonly DataContext _context; //private readonly variable
        public UsersController(DataContext context) //Generated Constructor - Dependancy Injection
        // Using DataContext
        {
            _context = context; // Intializing field from parameter
        }


        /** -- Use asynchronous when possible -- **/

        // End point to get all users from dB
        [HttpGet]
        // IEnumerable allows us to use simple iteration over a collection of a specified type
        // More appropiate as we do not need to sort or search
        // public ActionResult<IEnumerable<AppUser>> GetUsers()   - Sending back list of users to the client

        //Async wait, pauses, gets tasks and uses await to get the tasks
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()   //Using system threading task
        {
            return await _context.Users.ToListAsync(); //The list becomes asynchronous, returning asynchonously
        }


        // End point to get individual users
        // specified route parameter for example -  api/users/3 - 3 is the id fetched
        [HttpGet("{id}")] // Specified route parameter
        public async Task<ActionResult<AppUser>> GetUser(int id) // Takes id from route parameter
        {
          return await _context.Users.FindAsync(id); //User FindAsync method to get the user 
        }
    }
}

