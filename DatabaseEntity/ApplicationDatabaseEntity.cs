using Microsoft.EntityFrameworkCore;
using TotallyNotADatingApp_.Entities;

namespace TotallyNotADatingApp_.DatabaseEntity
{
    public class ApplicationDatabaseEntity : DbContext
    {
        public ApplicationDatabaseEntity(DbContextOptions<ApplicationDatabaseEntity> options) : base(options)
        { }

        public DbSet<AppUser> Users { get; set; }
    }
}
