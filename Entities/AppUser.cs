using System.ComponentModel.DataAnnotations;

namespace TotallyNotADatingApp_.Entities
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
