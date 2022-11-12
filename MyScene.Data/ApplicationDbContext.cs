
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MyScene.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public virtual DbSet<Artist> Artists { get; set; } 
        public virtual DbSet<Band> Bands { get; set; } 
        public virtual DbSet<Venue> Venues { get; set; } 


    }
}