using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    //Dessa är att tolkas som nosql egentligen, Speciellt comments bryter ju annars mot normalisering
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<ShowCaseEntity> ShowCases { get; set; }
}
