using Microsoft.EntityFrameworkCore;

namespace MalinsProjectVT23.Data;

public class DataInitializer
{
    public void MigrateAndSeed(ApplicationDbContext dbContext)
    {
        dbContext.Database.Migrate();

        SeedShape(dbContext);
        dbContext.SaveChanges();
    }

    private void SeedShape(ApplicationDbContext dbContext)
    {
        if (!dbContext.Shapes.Any())
        {
            dbContext.ShapeResults.Add(new ShapeResult
            {
                Area = 4 * 5 / 2,
                Circumference = 5 * 3,
                Height = 4,
                Length = 5,
                ResultDate = DateTime.Now,
                Shape = new Shape
                {
                    Name = "Triangle"
                }
            });
            dbContext.ShapeResults.Add(new ShapeResult
            {
                Area = 4 * 5,
                Circumference = (4 + 5) * 2,
                Height = 4,
                Length = 5,
                ResultDate = DateTime.Now,
                Shape = new Shape
                {
                    Name = "Parallelogram"
                }
            });
        }
    }
}