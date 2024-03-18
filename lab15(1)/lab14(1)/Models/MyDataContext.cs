using lab14_1_.Models;
using Microsoft.EntityFrameworkCore;

public class MyDataContext : DbContext
{
    public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
    {
    }

 
    public DbSet<MyDataModel1> mydatamodel1 { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyDataModel1>().ToTable("mydatamodel1");
        modelBuilder.Entity<MyDataModel1>().HasData(
            new MyDataModel1 { id = 1, name = "Example 1" },
            new MyDataModel1 { id = 2, name = "Example 2" }
        );
    }
}
