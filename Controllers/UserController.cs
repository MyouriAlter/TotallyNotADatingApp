using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotallyNotADatingApp.DatabaseEntity;
using TotallyNotADatingApp.Entities;

namespace TotallyNotADatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDatabaseEntity _database;

        public UserController(ApplicationDatabaseEntity database)
        {
            _database = database;
        }

        //get all users
        //api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _database.Users.ToListAsync();
        }

        //api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _database.Users.FindAsync(id);
        }
    }
}