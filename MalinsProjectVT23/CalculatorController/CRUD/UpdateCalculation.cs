﻿using MalinsProjectVT23.Data;
using MalinsProjectVT23.Interface;

namespace MalinsProjectVT23.CalculatorController.CRUD
{
    public class UpdateCalculation : ICrud
    {
        public UpdateCalculation(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public ApplicationDbContext DbContext { get; set; }
        public void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}