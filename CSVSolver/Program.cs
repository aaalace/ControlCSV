using LibCSV;
using LibUtils;

namespace CSVSolver;

public static class Program
{
    public static void Main()
    {
        do
        {
            // Calls get path method and checks for its state.
            int pathStatus = ConsoleInteraction.GetAbsolutePath(out string path);
            if (pathStatus == ConstantItems.StatusError)
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
                continue;
            }

            // Calls read data from csv method and checks for its state.
            string[] fileData = CsvProcessing.Read(in path, out int dataStatus);
            if (dataStatus == ConstantItems.StatusError)
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
                continue;
            }

            do
            {
                // Gets choice from menu method, checks for its state and launches TaskManager.
                int menuStatus = ConsoleInteraction.GetMenuChoice(out int menuChoice);
                if (menuStatus == ConstantItems.StatusError)
                {
                    continue;
                }
                if (menuChoice >= ConstantItems.StopMenuCycleAndSaveOption)
                {
                    if (menuChoice == ConstantItems.StopMenuCycleAndSaveOption)
                    {
                        // Save
                    }
                    break;
                }
                TaskManager.Manage(in menuChoice);
            } while (true);
            
            ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
        } while (Console.ReadKey(true).Key != ConsoleKey.Q);
    }
}