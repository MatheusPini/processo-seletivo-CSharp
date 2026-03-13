using BlogMonolito.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMonolito.Data;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
}