using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.CalculatorController;

public interface IMenu
{
    void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext);
}