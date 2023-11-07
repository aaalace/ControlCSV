using LibUtils;

namespace LibCSV;

public static class CsvProcessing
{
    private static string fPath = string.Empty;
    
    public static string[] Read(in string path, out int dataStatus)
    {
        fPath = path;
        string[] arr = Array.Empty<string>();
        dataStatus = ConstantItems.StatusOk;
        
        try
        {
            // file checking + data getting
        }
        catch (ArgumentNullException e)
        {
            dataStatus = ConstantItems.StatusError;
            ConsoleInteraction.MessagesWriter(e.Message, 2);
        }

        return arr;
    }
}