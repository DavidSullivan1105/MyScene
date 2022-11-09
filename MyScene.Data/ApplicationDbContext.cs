
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MyScene.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public virtual DbSet<Artist> Artist { get; set; } = null!;
        public virtual DbSet<Band> Band { get; set; } = null!;
        public virtual DbSet<Venue> Venue { get; set; } = null!;


    }
}