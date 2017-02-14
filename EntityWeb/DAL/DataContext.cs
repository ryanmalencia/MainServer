using System.Data.Entity;
using DataTypes;

namespace EntityWeb.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {

        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<OS>OSes { get; set; }
        public DbSet<Job>Jobs { get; set; }
        public DbSet<Pool>Pools { get; set; }
        public DbSet<JobTask>JobTasks { get; set; }
        public DbSet<AppDevice>Devices { get; set; }
        public DbSet<Sport>Sports { get; set; }
        public DbSet<SportEvent>SportEvents { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<SportEventAttend>SportEventAttendees { get; set; }
        public DbSet<Concert>Concerts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}