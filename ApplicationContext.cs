using Constellations.Models;
using Microsoft.EntityFrameworkCore;

namespace Constellations;

public class ApplicationContext : DbContext
{
    public DbSet<Constellation>? Constellations { get; set; }
    public DbSet<Star>? Stars { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        => builder.UseNpgsql(
            "Host=dpg-cedr1b9a6gdgn5f892hg-a.frankfurt-postgres.render.com;" +
            "Database=scrapyard;" +
            "Username=sweeper;" +
            "Password=5uHR6lvAAaVA1VnK83vEeQzaszMt6CLR;"
        );
}