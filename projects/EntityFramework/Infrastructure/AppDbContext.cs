using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Infrastructure;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
}
