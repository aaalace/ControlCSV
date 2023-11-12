using LibUtils;

namespace LibCSV;

public static class DataProcessing
{
    public static string[][] CoverageAreaChoosing(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        
        string covAreaInput = ConsoleInteraction.GetStringForSelection(out int selectionState);
        if (selectionState == ConstantItems.StatusOk)
        {
            resultData = data.Where(x => x[7] == covAreaInput).ToArray();
        }
        
        return resultData;
    }
    
    public static string[][] ParkNameChoosing(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        
        string parkNameInput = ConsoleInteraction.GetStringForSelection(out int selectionState);
        if (selectionState == ConstantItems.StatusOk)
        {
            resultData = data.Where(x => x[5] == parkNameInput).ToArray();
        }
        
        return resultData;
    }
    
    public static string[][] AdmAndCoverageAreaChoosing(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();

        string admAreaInput = ConsoleInteraction.GetStringForSelection(out int selectionAdmState);
        string covAreaInput = ConsoleInteraction.GetStringForSelection(out int selectionCovState);
        if (selectionAdmState == ConstantItems.StatusOk & selectionCovState == ConstantItems.StatusOk)
        {
            resultData = data.Where(x => x[3] == admAreaInput & x[7] == covAreaInput).ToArray();
        }
        
        return resultData;
    }
    
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