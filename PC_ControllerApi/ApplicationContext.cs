using Microsoft.EntityFrameworkCore;
using PC_ControllerApi.EntitiesConfigurations;
using PC_ControllerApi.EntityBuilders;
using PC_ControllerApi.Models;
using System.Diagnostics;

namespace PC_ControllerApi
{
    public class ApplicationContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PC> PCes { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected ApplicationContext()
        {
           
            Database.EnsureCreated();
            
        }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>(new UserConfiguration<User>().Configure);
            modelBuilder.Entity<PC>(new PCConfiguration<PC>().Configure);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<PC>();
        }
    }
}
