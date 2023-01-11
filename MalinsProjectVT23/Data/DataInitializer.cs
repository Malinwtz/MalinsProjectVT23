﻿using Microsoft.EntityFrameworkCore;

namespace MalinsProjectVT23.Data;

public class DataInitializer
{
    public void MigrateAndSeed(ApplicationDbContext dbContext)
    {
        dbContext.Database.Migrate();
        
        //SeedShapeResult(dbContext);
        dbContext.SaveChanges();
    }
}