using MalinsProjectVT23.ShapeController;
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
                Area = (48*50)/2,
                Circumference = 50*3,
                Height = 48,
                Length = 50,
                ResultDate = DateTime.Now,
                Shape = new Shape
                {
                    Name = "Triangle" //parallelogram - enum?
                }
            });
            dbContext.ShapeResults.Add(new ShapeResult
            {
                Area = 48*50,
                Circumference = (48+50)*2,
                Height = 48,
                Length = 50,
                ResultDate = DateTime.Now,
                Shape = new Shape 
                {
                    Name = "Parallelogram" //parallelogram - enum?
                }
            });
        }
    }
}