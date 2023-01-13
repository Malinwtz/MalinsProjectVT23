using ClassLibraryCalculations.Interface;
using MalinsProjectVT23.Data;

namespace MalinsProjectVT23.Interface;

public interface ICrudCalculation
{
    void RunCrud(int selectedFromMenu); //tagit bort calcstrategy och dbcontext
}