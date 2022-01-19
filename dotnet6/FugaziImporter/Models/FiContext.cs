using Microsoft.EntityFrameworkCore;


namespace FugaziImporter.Models
{
    public class FiContext : DbContext
    {
        public FiContext(DbContextOptions<FiContext> options): base(options){}

        //public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<FugaziImport> FugaziImport => Set<FugaziImport>();
    }
}