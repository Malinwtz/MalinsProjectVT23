using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalinsProjectVT23.ShapeController.Shapes;

namespace MalinsProjectVT23.Data
{
    public class Builder
    {
        public Builder(ShapeEnum shapeEnum)
        {
            ShapeEnum = shapeEnum;
        }
        public IConfigurationRoot config { get; set; }
        public ShapeEnum ShapeEnum { get; set; }

        public void BuildProject()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
            config = builder.Build();
        }

        public ApplicationDbContext ConnectProject()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                var dataInitiaizer = new DataInitializer(ShapeEnum);
                dataInitiaizer.MigrateAndSeed(dbContext);

                var dbContextReturned = new ApplicationDbContext(options.Options);
                return dbContextReturned;
            }
        }
    }
}
