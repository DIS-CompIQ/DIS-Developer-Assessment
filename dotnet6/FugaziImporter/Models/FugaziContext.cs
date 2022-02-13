using FugaziImporter.Models;
using Microsoft.EntityFrameworkCore;

namespace FugaziImporter.Models
{
    public class FugaziContext : DbContext
    {
        public FugaziContext(DbContextOptions<FugaziContext> options): base(options){}

        public DbSet<FugaziImport> FugaziImport {get; set;}
    }
}