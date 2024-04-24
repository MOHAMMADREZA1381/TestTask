using Microsoft.EntityFrameworkCore;
using Test.Domain.Models.Product;
using Test.Domain.Models.User;

namespace Infra.Test.Data.Context;

public class TestTaskContext:DbContext
{
    public TestTaskContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

}