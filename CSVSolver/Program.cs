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
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint, 1);
                continue;
            }

            // Calls read data from csv method and checks for its state, initialData - data right from file.
            string[] initialData = CsvProcessing.Read(in path, out int dataStatus);
            if (dataStatus == ConstantItems.StatusError)
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint, 1);
                continue;
            }
            
            // Changes data format, workData - data without headers.
            string[][] workData = CsvProcessing.RemakeData(in initialData, out int remakeStatus);
            if (remakeStatus == ConstantItems.StatusError)
            {
                ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint, 1);
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
                
                // StopMenuAndSaveOption = 7; StopMenuOption = 8.
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
                        
                        // If pushData contains 1 row (not including headers) then Write(string) else Write(string[]);
                        switch (pushData.Length)
                        {
                            case < 3:
                                ConsoleInteraction.MessagesWriter(ErrorMessages.CantSaveEmpty, 2);
                                break;
                            case 3:
                                string nPath = ConsoleInteraction.GetNPath(out bool beenExist);
                                CsvProcessing.Write(pushData[2], nPath, beenExist);
                                break;
                            case > 3:
                                CsvProcessing.Write(pushData);
                                break;
                        }
                    }
                    break;
                }
                
                // Launches task in addition of menuChoice (1 - 5).
                resultData = TaskManager.Manage(in menuChoice, in workData);
                ConsoleInteraction.PrintData(in resultData, ConstantItems.visibleOptions[menuChoice - 1]);
            } while (true);
            
            ConsoleInteraction.MessagesWriter(SystemMessages.ExitPoint, 1);
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