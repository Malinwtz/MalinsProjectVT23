using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.CalculatorController;

public interface ICrud
{
    void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext);
}