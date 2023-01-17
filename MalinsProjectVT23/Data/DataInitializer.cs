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
        dbContext.SaveChanges();
    }
    private void SeedShape(ApplicationDbContext dbContext)
    {
        if (!dbContext.Shapes.Any())
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
                Name = ShapeEnum.TypeOfShape.Rhombus.ToString(),
            });

            dbContext.Shapes.Add(new Shape
            {
                Name = ShapeEnum.TypeOfShape.Triangle.ToString(),
            });
        }
    }
}