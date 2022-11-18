using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:IdentityDbContext<User>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
}