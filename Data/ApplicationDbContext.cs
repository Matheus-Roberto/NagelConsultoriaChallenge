using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NagelConsultoriaChallenge.Models;

namespace NagelConsultoriaChallenge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Logs> Logs { get; set; }
    }
}