using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalinsProjectVT23.ShapeController;

namespace MalinsProjectVT23.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            //SeedShape(dbContext);
            //SeedCustomer(dbContext);
            dbContext.SaveChanges();
        }

        private void SeedShape(ApplicationDbContext dbContext)
        {
            if (!dbContext.ShapeResults.Any())
            {
                dbContext.ShapeResults.Add(new ShapeResult
                {
                    Height = 37,
                    Length = 80,
                    Area = 80 * 37
                });
            }
        }
    }
}
