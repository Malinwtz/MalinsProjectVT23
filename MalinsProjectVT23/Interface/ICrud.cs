using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.Interface;

public interface ICrud
{
    void RunMenuOptions(int selectedFromMenu, ApplicationDbContext dbContext);
}