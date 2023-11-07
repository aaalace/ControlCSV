using LibCSV;
using LibUtils;

namespace CSVSolver;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            // Calls get path method and checks for its state.
            int pathKeyCode = ConsoleInteraction.GetAbsolutePath(out string path);
            if (pathKeyCode == ConstantItems.KeyCodes[1])
            {
                continue;
            }

            // Calls read data from csv method and checks for its state.
            string[] fileData = CsvProcessing.Read(in path, out int dataKeyCode);
            if (dataKeyCode == ConstantItems.KeyCodes[1])
            {
                continue;
            }
            
            do
            {
                // Calls get choice from menu method and checks for its state.
                int menuKeyCode = ConsoleInteraction.GetMenuChoice(out int menuChoice);
                if (menuKeyCode == ConstantItems.KeyCodes[1])
                {
                    continue;
                }
                if (menuChoice == 6)
                {
                    ConsoleInteraction.MessagesWriter("finished correct");
                    // ОРГАНИЗОВАТЬ ЗДЕСЬ ВЫХОД ИЗ ПРОГРАММЫ В ЦЕЛОМ
                    break;
                }
            } while (true);

            Console.WriteLine("to be continued");
        }
    }
}