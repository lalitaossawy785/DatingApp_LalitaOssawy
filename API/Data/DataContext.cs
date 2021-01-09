using API.Entities; //Bring in AppUsers using Entities
using Microsoft.EntityFrameworkCore; //Using statement 

namespace API.Data //Based on API Folder and Data Folder - easy to track when made this way 
{
    public class DataContext : DbContext //DbContext represents a session with the database and can be used to query and save instances of your entities.
    {
        //Constructor - passing options when added to configuration, dependency injection container
        public DataContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<AppUser> Users { get; set; } //Configureation for DbSet
    }
}