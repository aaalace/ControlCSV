﻿namespace LibUtils;

public static class ConsoleInteraction
{
    // Custom message writer. Paints message in different color depending on colorCode.
    public static void MessagesWriter(string message, int colorCode = 0)
    {
        Console.ForegroundColor = ConstantItems.ConsoleColors[colorCode];
        Console.Write(message);
        Console.Write(Environment.NewLine);
        Console.ForegroundColor = ConstantItems.ConsoleColors[0];
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
            return ConstantItems.KeyCodes[0];
        }
        MessagesWriter(ErrorMessages.PathError, 2);
        return ConstantItems.KeyCodes[1];
    }

    // Gets and checks user's choice in menu on type and value.
    public static int GetMenuChoice(out int menuChoice)
    {
        
        MessagesWriter(SystemMessages.BeforeMenuChoice);
        MessagesWriter(SystemMessages.MenuChoices);
        bool choiceCorrectTypeState = int.TryParse(Console.ReadLine(), out menuChoice);
        if (!choiceCorrectTypeState)
        {
            MessagesWriter(ErrorMessages.MenuTypeError, 2);
            return ConstantItems.KeyCodes[1];
        }
        // User can choose only 5 options in menu
        if (menuChoice < 1 | menuChoice > 5)
        {
            MessagesWriter(ErrorMessages.MenuAreaError, 2);
            return ConstantItems.KeyCodes[1];
        }
        return ConstantItems.KeyCodes[0];
    }
}