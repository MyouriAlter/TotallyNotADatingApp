using TotallyNotADatingApp.Entities;

namespace TotallyNotADatingApp.Interfaces
{
    public interface ITokenServices
    {
        string CreateToken(AppUser user);
        
    }
}