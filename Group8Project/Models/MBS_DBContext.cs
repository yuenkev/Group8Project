// Author: Kevin Yuen   
// Description: DB Context for migrations


using Microsoft.EntityFrameworkCore;

namespace Group8Project.Models
{
    public class MBS_DBContext : DbContext
    {
        public MBS_DBContext(DbContextOptions<MBS_DBContext> options) : base(options) { }

        //entity
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        

    }
}
