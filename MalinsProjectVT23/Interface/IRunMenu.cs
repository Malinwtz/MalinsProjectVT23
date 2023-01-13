using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.Interface;

public interface IRunMenu
{
    void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext);
}