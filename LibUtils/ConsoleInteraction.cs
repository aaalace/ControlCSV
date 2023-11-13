namespace LibUtils;

public static class ConsoleInteraction
{
    // Gets and checks user's typed path on null.
    public static int GetAbsolutePath(out string path)
    {
        MessagesWriter(SystemMessages.BeforePathGetting, 1);
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
    
    // Gets nPath.
    public static string GetNPath()
    {
        MessagesWriter(SystemMessages.BeforeFileNameGetting, 1);
        string nPath;
        while (true)
        {
            try
            {
                string? inputPath = Console.ReadLine();
                nPath = inputPath ?? throw new ArgumentNullException(nameof(inputPath));
                var myFile = File.Open(inputPath, FileMode.Open);
                myFile.Close();
                break;
            }
            catch (Exception)
            {
                MessagesWriter(ErrorMessages.PathError, 2);
            }
        }
        return nPath;
    }

    // Gets and checks user's choice in menu on type and value.
    public static int GetMenuChoice(out int menuChoice)
    {
        
        MessagesWriter(SystemMessages.MenuTitle, 1);
        for (int i = 0; i <= 6; i++)
        {
            MessagesWriter((i + 1).ToString(), 1, ") ");
            MessagesWriter(SystemMessages.MenuChoices[i]);
        }
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

    
    // Gets value for selection (1 - 3 menu options).
    public static string GetStringForSelection(out int selectionState, string addVal = "")
    {
        selectionState = ConstantItems.StatusOk;
        MessagesWriter(SystemMessages.BeforeSelection + addVal, 1);
        
        string? returnString = Console.ReadLine();
        if (returnString == null)
        {
            returnString = "";
            selectionState = ConstantItems.StatusError;
            MessagesWriter(ErrorMessages.SelectionError, 2);
        }
        return returnString;
    }
    
    // Custom message writer. Paints message in different color depending on colorCode.
    public static void MessagesWriter(string message, int colorCode = 0, string sep = "\n")
    {
        Console.ForegroundColor = ConstantItems.ConsoleColors[colorCode];
        Console.Write(message);
        Console.Write(sep);
        Console.ResetColor();
    }

    // Writes data in console.
    public static void PrintData(in string[][] data, int[] visibleOptions)
    {
        try
        {
            if (data.Length == 0)
            {
                MessagesWriter(SystemMessages.EmptyResult, 2);
                return;
            } 
            
            const string separator = " | ";
            
            // English header.
            for (int i = 0; i < ConstantItems.initHeadRowEn.Length; i++)
            {
                if (!visibleOptions.Contains(i))
                {
                    continue;
                }
                string element = ConstantItems.initHeadRowEn[i];
                Console.ForegroundColor = ConstantItems.CellColors[i % 3];
                Console.Write(element);
                Console.ResetColor();
                Console.Write(separator);
            }
            Console.Write(Environment.NewLine);
        
            // Russian header.
            for (int i = 0; i < ConstantItems.initHeadRowRu.Length; i++)
            {
                if (!visibleOptions.Contains(i))
                {
                    continue;
                }
                string element = ConstantItems.initHeadRowRu[i];
                Console.ForegroundColor = ConstantItems.CellColors[i % 3];
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
                    if (!visibleOptions.Contains(i))
                    {
                        continue;
                    }
                    string element = row[i];
                    if (string.IsNullOrEmpty(element))
                    {
                        continue;
                    }
                    Console.ForegroundColor = ConstantItems.CellColors[i % 3];
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