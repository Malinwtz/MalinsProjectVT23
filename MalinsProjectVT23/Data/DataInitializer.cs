using MalinsProjectVT23.ShapeController.Shapes;
using Microsoft.EntityFrameworkCore;

namespace MalinsProjectVT23.Data;

public class DataInitializer
{
    public DataInitializer(ShapeEnum shapeEnum)
    {
        ShapeEnum = shapeEnum;
    }

    public ShapeEnum ShapeEnum { get; set; }
    public void MigrateAndSeed(ApplicationDbContext dbContext)
    {
        dbContext.Database.Migrate();

        SeedShape(dbContext);
        SeedShapeResult(dbContext);
        dbContext.SaveChanges();
    }
    private void SeedShape(ApplicationDbContext dbContext)
    {

        dbContext.Shapes.Add(new Shape
            {
                Name = ShapeEnum.TypeOfShape.Parallelogram.ToString(),  
            });
            dbContext.Shapes.Add(new Shape
            {
                Name = ShapeEnum.TypeOfShape.Rectangle.ToString(),
            });
            dbContext.Shapes.Add(new Shape
            {
                Name =  ShapeEnum.TypeOfShape.Rhombus.ToString(),
            });

            dbContext.Shapes.Add(new Shape
            {
                Name = ShapeEnum.TypeOfShape.Triangle.ToString(),
            });

    }
    private void SeedShapeResult(ApplicationDbContext dbContext)
    {

        if (!dbContext.ShapeResults.Any())
        {
            dbContext.ShapeResults.Add(new ShapeResult
            {
                Area = 4 * 5 / 2,
                Circumference = 5 * 3,
                Height = 4,
                Length = 5,
                ResultDate = DateTime.Now,
                Shape = new Shape ///skriv formens siffra istället.
                {
                    Name = ShapeEnum.TypeOfShape.Triangle.ToString(),
                    // Convert.ToInt32(ShapeEnum.TypeOfShape.Parallelogram).ToString() - visar enumens siffra!
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
                    Name = ShapeEnum.TypeOfShape.Parallelogram.ToString(),
                }
            });
        }
    }
}