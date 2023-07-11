using DormCoreApp.Config;
using DormCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DormCoreApp.Servers
{
    public class DormDatabaseContext : DbContext
    {
        public DbSet<Dorm> Dorm { get; set; }
        public DbSet<User> User { get; set; }  
        public DbSet<Room> Room { get; set; }
        public DbSet<Authority> Authorities{ get; set; }
        public DbSet<Role> Role{ get; set; }
        public DbSet<Accomodation> Accommodation { get; set; }
        
    }
}
