namespace LibUtils;

// Classes of messages of program.
public static class SystemMessages
{
    public const string ExitPoint = "Press Q to finish | Press any other key to continue";
    public const string BeforePathGetting = "Type absolute path:";
    public const string BeforeFileNameGetting = "Type filename:";
    public const string MenuTitle = "Menu:";
    public static readonly string[] MenuChoices = { 
        "Select by CoverageArea", 
        "Select by ParkName", 
        "Select by AdmArea and CoverageArea",
        "Sort by Name (alphabetical order)",
        "Sort by CoverageArea (increasing order)",
        "Close and save current file",
        "Close current file !without save!"
    };
    public const string BeforeSelection = "Value for selection:";
    public const string EmptyResult = "The set of current values is empty";
}

public static class ErrorMessages
{
    public const string PathError = "Path error, try again";
    public const string CantSaveEmpty = "You cant save empty file";
    public const string MenuTypeError = "Menu type error";
    public const string MenuAreaError = "Menu area error";
    public const string CustomOpenFileError = "File not found or file contains incorrect data";
    public const string UnexpectedError = "Unexpected error occured";
    public const string NotFullPathError = "Path is not absolute";
    public const string WrongPathWhileReadError = "Incorrect path";
    public const string WrongRemakeData = "Error in remake data";
    public const string DataRefactorError = "Error in refactor data";
    public const string SelectionError = "Error in selection";
    public const string WriteError = "Error while write data to file";
    
    public const string WrongCoverageAreaChoosing = "Error in choosing by CoverageArea";
    public const string WrongParkNameChoosing = "Error in choosing by Name";
    public const string WrongAdmAndCoverageAreaChoosing = "Error in choosing by AdmArea and CoverageArea";
    public const string WrongNameSorting = "Error in sorting by Name";
    public const string WrongCoverageAreaSorting = "Error in sorting by CoverageArea";
}