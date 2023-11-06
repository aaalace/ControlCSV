using LibCSV;
using LibUtils;

namespace CSVSolver;

public static class Program
{
    public static void Main()
    {
        do
        {
            int pathKeyCode = AbsolutePathExpect(out string? path);
            if (pathKeyCode == ConstantItems.KeyCodes[1])
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
                continue;
            }
            
            int menuKeyCode = Menu(out int menuChoice);
            if (menuKeyCode == ConstantItems.KeyCodes[1])
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
                continue;
            }

            Console.WriteLine($"{path} | {menuChoice}");
            ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);

        } while (Console.ReadKey(true).Key != ConsoleKey.Q);
    }

    private static int AbsolutePathExpect(out string? path)
    {
        ConsoleInteraction.MessagesWriter(SystemMessages.BeforePathGetting);
        int keyCode = ConsoleInteraction.GetAbsolutePath(out path);
        if (keyCode == ConstantItems.KeyCodes[1])
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.PathError, 2);
        }
        return keyCode;
    }

    private static int Menu(out int menuChoice)
    {
        ConsoleInteraction.MessagesWriter(SystemMessages.BeforeMenuChoice);
        int keyCode = ConsoleInteraction.GetMenuChoice(out menuChoice);
        if (keyCode == ConstantItems.KeyCodes[1])
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.MenuError, 2);
        }
        return keyCode;
    }
}