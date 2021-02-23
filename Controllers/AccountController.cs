using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotallyNotADatingApp.DatabaseEntity;
using TotallyNotADatingApp.DTO;
using TotallyNotADatingApp.Entities;
using TotallyNotADatingApp.Interfaces;

namespace TotallyNotADatingApp.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationDatabaseEntity _database;
        private readonly ITokenServices _tokenServices;

        public AccountController(ApplicationDatabaseEntity database, ITokenServices tokenServices)
        {
            _database = database;
            _tokenServices = tokenServices;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> RegisterUser(RegistrationDTO registrationDto)
        {
            
            if (await UserExist(registrationDto.Username))
                return BadRequest("Username is already registered!!");
            
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registrationDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registrationDto.Password)),
                PasswordSalt = hmac.Key
            };
            
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();
            
            return new UserDTO
            {
                Username = user.UserName,
                Token = _tokenServices.CreateToken(user)
            };
            
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _database.Users.SingleOrDefaultAsync(x 
                => x.UserName == loginDto.Username);
            if (user == null)
                return Unauthorized("Invalid username!!");
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            
            var computedHash = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(loginDto.Password));

            if (computedHash.Where((t, i) => t != user.PasswordHash[i]).Any())
                return Unauthorized("Invalid password!");
            
            return new UserDTO
            {
                Username = user.UserName,
                Token = _tokenServices.CreateToken(user)
            };
        }

        public async Task<bool> UserExist(string userName)
        {
            return await _database.Users.AnyAsync(x 
                => x.UserName.ToLower().Equals(userName.ToLower()));
        }
        
    }
}