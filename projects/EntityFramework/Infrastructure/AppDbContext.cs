using Bogus;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Infrastructure;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Models.Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var person = new Faker<Models.Person>()
                .RuleFor(p => p.PersonId, _ => Guid.NewGuid())
                .RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(p => p.Name, f => f.Person.FirstName)
                .RuleFor(p => p.Gender, f => (f.Person.Random.Digits(1)[0] % 2) == 0 ? Gender.Male : Gender.Female)
                .Generate();
    }
}
