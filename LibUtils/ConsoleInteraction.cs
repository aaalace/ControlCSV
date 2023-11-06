namespace LibUtils;

public static class ConsoleInteraction
{
    public static void MessagesWriter(string message, int colorCode = 0)
    {
        Console.ForegroundColor = ConstantItems.ConsoleColors[colorCode];
        Console.Write(message);
        Console.Write(Environment.NewLine);
        Console.ForegroundColor = ConstantItems.ConsoleColors[0];
    }
    
    public static int GetAbsolutePath(out string? path)
    {
        path = Console.ReadLine();
        return path != null ? ConstantItems.KeyCodes[0] : ConstantItems.KeyCodes[1];
    }

    public static int GetMenuChoice(out int menuChoice) => 
        int.TryParse(Console.ReadLine(), out menuChoice) ? ConstantItems.KeyCodes[0] : ConstantItems.KeyCodes[1];
}