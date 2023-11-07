using LibUtils;

namespace LibCSV;

public static class CsvProcessing
{
    private static string fPath = string.Empty;
    
    public static string[] Read(in string path, out int dataKeyCode)
    {
        fPath = path;
        string[] arr = Array.Empty<string>();
        dataKeyCode = ConstantItems.KeyCodes[0];
        
        try
        {
            // file checking + data getting
        }
        catch (ArgumentNullException e)
        {
            dataKeyCode = 200;
            ConsoleInteraction.MessagesWriter(e.Message, 2);
        }

        return arr;
    }
}