using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.PublicationDate).HasColumnName("PublicationDate");
            });

            ProgrammingLanguage[] programmingLanguages = { new(1, "C#", 2002), new(2, "Java", 1995) };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguages);
        }
    }
}
