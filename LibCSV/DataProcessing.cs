using LibUtils;

namespace LibCSV;

public static class DataProcessing
{
    // public static string[][] CoverageAreaChoosing(string[][] data)
    // {
    //     
    // }
    //
    // public static string[][] ParkNameChoosing(string[][] data)
    // {
    //     
    // }
    //
    // public static string[][] AdmAndCoverageAreaChoosing(string[][] data)
    // {
    //     
    // }
    
    public static string[][] NameSorting(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        
        try
        {
            resultData = data[2..].OrderBy(entry => entry[2]).ToArray();
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WrongNameSorting);
        }
        return resultData;
    }
    
    public static string[][] CoverageAreaSorting(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        try
        {
            resultData = data[2..].OrderBy(entry => int.Parse(entry[7])).ToArray();
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WrongCoverageAreaSorting);
        }
        return resultData;
    }
}