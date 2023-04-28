using Microsoft.EntityFrameworkCore;
using OvetimePolicies_Core.Entities;

namespace OvetimePolicies_Data;

sealed public class ApplicationDBContext : DbContext
{

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }


    public DbSet<Person> Person { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
