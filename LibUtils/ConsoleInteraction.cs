using System.Text;

namespace LibUtils;

public static class ConsoleInteraction
{
    // Custom message writer. Paints message in different color depending on colorCode.
    public static void MessagesWriter(string message, int colorCode = 0)
    {
        Console.ForegroundColor = ConstantItems.ConsoleColors[colorCode];
        Console.Write(message);
        Console.Write(Environment.NewLine);
        Console.ResetColor();
    }
    
    // Gets and checks user's typed path on null.
    public static int GetAbsolutePath(out string path)
    {
        MessagesWriter(SystemMessages.BeforePathGetting);
        path = string.Empty;
        string? inputPath = Console.ReadLine();
        if (inputPath != null)
        {
            path = inputPath;
            return ConstantItems.StatusOk;
        }
        MessagesWriter(ErrorMessages.PathError, 2);
        return ConstantItems.StatusError;
    }

    // Gets and checks user's choice in menu on type and value.
    public static int GetMenuChoice(out int menuChoice)
    {
        
        MessagesWriter(SystemMessages.MenuChoices);
        bool choiceCorrectTypeState = int.TryParse(Console.ReadLine(), out menuChoice);
        if (!choiceCorrectTypeState)
        {
            MessagesWriter(ErrorMessages.MenuTypeError, 2);
            return ConstantItems.StatusError;
        }
        // User can choose only 7 options in menu
        if (menuChoice < 1 | menuChoice > 7)
        {
            MessagesWriter(ErrorMessages.MenuAreaError, 2);
            return ConstantItems.StatusError;
        }
        return ConstantItems.StatusOk;
    }

    // Writes data in console.
    public static void PrintData(in string[][] data)
    {
        try
        {
            // English header.
            for (int i = 0; i < ConstantItems.initHeadRowEn.Length; i++)
            {
                string element = ConstantItems.initHeadRowEn[i];
                string separator = i == ConstantItems.initHeadRowEn.Length - 1 ? "\n" : " | ";
                Console.ForegroundColor = ConstantItems.CellColors[i % 5];
                Console.Write(element);
                Console.ResetColor();
                Console.Write(separator);
            }
            Console.Write(Environment.NewLine);
        
            // Russian header.
            for (int i = 0; i < ConstantItems.initHeadRowRu.Length; i++)
            {
                string element = ConstantItems.initHeadRowRu[i];
                string separator = i == ConstantItems.initHeadRowRu.Length - 1 ? "\n" : " | ";
                Console.ForegroundColor = ConstantItems.CellColors[i % 5];
                Console.Write(element);
                Console.ResetColor();
                Console.Write(separator);
            }
            Console.Write(Environment.NewLine);
        
            // Formatted data in table.
            foreach (string[] row in data)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    string element = row[i];
                    if (string.IsNullOrEmpty(element))
                    {
                        continue;
                    }
                    string separator = i == row.Length - 1 ? "\n" : " | ";
                    Console.ForegroundColor = ConstantItems.CellColors[i % 5];
                    Console.Write(element);
                    Console.ResetColor();
                    Console.Write(separator);
                }
                Console.Write(Environment.NewLine);
            }
        }
        catch (Exception)
        {
            MessagesWriter(ErrorMessages.DataRefactorError, 2);
        }
    }
}