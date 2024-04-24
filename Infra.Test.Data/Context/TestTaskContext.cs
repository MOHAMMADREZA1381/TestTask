using Microsoft.EntityFrameworkCore;
using Test.Domain.Models.User;

namespace Infra.Test.Data.Context;

public class TestTaskContext:DbContext
{
    public TestTaskContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }


}