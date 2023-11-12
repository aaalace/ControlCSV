using LibCSV;
using LibUtils;

namespace CSVSolver;

public static class Program
{
    public static void Main()
    {
        do
        {
            // Changes after every option completed.
            string[][] resultData = Array.Empty<string[]>();
            
            // Calls get path method and checks for its state.
            int pathStatus = ConsoleInteraction.GetAbsolutePath(out string path);
            if (pathStatus == ConstantItems.StatusError)
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
                continue;
            }

            // Calls read data from csv method and checks for its state, initialData - data right from file.
            string[] initialData = CsvProcessing.Read(in path, out int dataStatus);
            if (dataStatus == ConstantItems.StatusError)
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
                continue;
            }
            
            // Changes data format, workData - data without headers.
            string[][] workData = CsvProcessing.RemakeData(in initialData, out int remakeStatus);
            if (remakeStatus == ConstantItems.StatusError)
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
                continue;
            }
            
            do
            {
                // Gets choice from menu method, checks for its state to launch TaskManager.
                int menuStatus = ConsoleInteraction.GetMenuChoice(out int menuChoice);
                if (menuStatus == ConstantItems.StatusError)
                {
                    continue;
                }
                
                // StopMenuAndSaveOption = 6; StopMenuOption = 7.
                if (menuChoice >= ConstantItems.StopMenuAndSaveOption)
                {
                    if (menuChoice == ConstantItems.StopMenuAndSaveOption)
                    {
                        // Changes data format back.
                        string[] pushData = CsvProcessing.RemakeDataBack(in resultData, out int remakeBackStatus);
                        if (remakeBackStatus == ConstantItems.StatusError)
                        {
                            break;
                        }
                        
                        CsvProcessing.Write(pushData);
                    }
                    break;
                }
                
                // Launches task in addition of menuChoice (1 - 5).
                resultData = TaskManager.Manage(in menuChoice, in workData);
                ConsoleInteraction.PrintData(in resultData);
            } while (true);
            
            ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint);
        } while (Console.ReadKey(true).Key != ConsoleKey.Q);
    }

    private static class TaskManager
    {
        public static string[][] Manage(in int menuChoice, in string[][] data)
        {
            string[][] resultData = menuChoice switch
            {
                1 => DataProcessing.CoverageAreaChoosing(data),
                2 => DataProcessing.ParkNameChoosing(data),
                3 => DataProcessing.AdmAndCoverageAreaChoosing(data),
                4 => DataProcessing.NameSorting(data),
                5 => DataProcessing.CoverageAreaSorting(data),
                _ => Array.Empty<string[]>()
            };

            return resultData;
        }
    }
}