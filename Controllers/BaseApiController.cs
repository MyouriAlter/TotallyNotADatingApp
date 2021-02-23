using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotallyNotADatingApp.DatabaseEntity;
using TotallyNotADatingApp.Entities;

namespace TotallyNotADatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}