using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TotallyNotADatingApp_.DatabaseEntity;
using TotallyNotADatingApp_.Entities;

namespace TotallyNotADatingApp_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDatabaseEntity _database;
        public UsersController(ApplicationDatabaseEntity database)
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
