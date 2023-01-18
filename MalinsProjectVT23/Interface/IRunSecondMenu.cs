using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.Interface;

public interface IRunSecondMenu
{
    void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext);
}