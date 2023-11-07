namespace LibUtils;

public static class ConstantItems
{
    // Status codes.
    public const int StatusOk = 100;
    public const int StatusError = 200;

    // Colors of different console states
    public static readonly ConsoleColor[] ConsoleColors = 
    { 
        ConsoleColor.White, 
        ConsoleColor.Green,
        ConsoleColor.Red
    };

    public const int StopMenuCycleAndSaveOption = 6;
    public const int StopMenuCycleOption = 7;
}