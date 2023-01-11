using Microsoft.EntityFrameworkCore;

namespace MalinsProjectVT23.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Calculation> Calculations { get; set; }
    public DbSet<RockScissorPaperGameResult> RockScissorPaperGameResults { get; set; }
    public DbSet<Shape> Shapes { get; set; }
    public DbSet<ShapeResult> ShapeResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=MalinsProjectDatabase;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}