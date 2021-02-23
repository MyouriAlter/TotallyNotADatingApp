using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotallyNotADatingApp.DatabaseEntity;
using TotallyNotADatingApp.Entities;

namespace TotallyNotADatingApp.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly ApplicationDatabaseEntity _database;

        public UserController(ApplicationDatabaseEntity database)
        {
            _database = database;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _database.Users.ToListAsync();
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _database.Users.FindAsync(id);
        }
    }
    
}