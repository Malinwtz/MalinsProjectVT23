using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalinsProjectVT23.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            //SeedRoom(dbContext);
            //SeedCustomer(dbContext);
            dbContext.SaveChanges();
        }
    }
}
