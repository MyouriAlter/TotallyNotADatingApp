using Microsoft.EntityFrameworkCore;
using TotallyNotADatingApp.Entities;

namespace TotallyNotADatingApp.DatabaseEntity
{
    public class ApplicationDatabaseEntity : DbContext
    {
        public ApplicationDatabaseEntity(DbContextOptions<ApplicationDatabaseEntity> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}