﻿using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.Interface;

public interface ICrudCalculation
{
    void RunCrud(int selectedFromMenu, ApplicationDbContext dbContext, ICalculateStrategy calculateStrategy);
}