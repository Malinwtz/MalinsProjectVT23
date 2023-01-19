using System.Drawing;
using ClassLibraryStrings;
using MalinsProjectVT23.Interface;
using MalinsProjectVT23.MainMenuController;
using Action = ClassLibraryStrings.Action;

namespace MalinsProjectVT23.ShapeController;

public class DisplayShapeMenu : IDisplayMenu
{
    public int ReturnSelectionFromMenu()
    {
        var endAlternative = 4;
        Action.DarkYellow("\n Shape Menu\n");
        Line.LineThreeStar();
        Action.Yellow(" 1. Rectangle\n");
        Action.Yellow(" 2. Parallelogram\n");
        Action.Yellow(" 3. Equilateral triangle\n");
        Action.Yellow($" {endAlternative}. Rhombus\n");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
}