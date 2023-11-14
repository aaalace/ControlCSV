using LibUtils;

namespace LibCSV;

public static class DataProcessing
{
    public static string[][] CoverageAreaChoosing(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        
        try
        {
            string covAreaInput = ConsoleInteraction.GetStringForSelection(out int selectionState);
            if (selectionState == ConstantItems.StatusOk)
            {
                resultData = data.Where(x => x[7] == covAreaInput).ToArray();
            }
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WrongCoverageAreaChoosing, 2);
        }
        
        return resultData;
    }
    
    public static string[][] ParkNameChoosing(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        
        try
        {
            string parkNameInput = ConsoleInteraction.GetStringForSelection(out int selectionState);
            if (selectionState == ConstantItems.StatusOk)
            {
                resultData = data.Where(x => x[5] == parkNameInput).ToArray();
            }
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WrongParkNameChoosing, 2);
        }
        
        return resultData;
    }
    
    public static string[][] AdmAndCoverageAreaChoosing(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        
        try
        {
            string admAreaInput = ConsoleInteraction.GetStringForSelection(out int selectionAdmState, " (AdmArea)");
            string covAreaInput = ConsoleInteraction.GetStringForSelection(out int selectionCovState, " (CovArea)");
            if (selectionAdmState == ConstantItems.StatusOk & selectionCovState == ConstantItems.StatusOk)
            {
                resultData = data.Where(x => x[3] == admAreaInput & x[7] == covAreaInput).ToArray();
            }
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WrongAdmAndCoverageAreaChoosing, 2);
        }
        
        return resultData;
    }
    
    public static string[][] NameSorting(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        
        try
        {
            resultData = data.OrderBy(entry => entry[2]).ToArray();
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WrongNameSorting, 2);
        }
        return resultData;
    }
    
    public static string[][] CoverageAreaSorting(string[][] data)
    {
        string[][] resultData = Array.Empty<string[]>();
        try
        {
            resultData = data.OrderBy(entry => int.Parse(entry[7])).ToArray();
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WrongCoverageAreaSorting, 2);
        }
        return resultData;
    }
}