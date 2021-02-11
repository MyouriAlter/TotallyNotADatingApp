using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotallyNotADatingApp_.Entities
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
