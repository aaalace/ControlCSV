namespace LibUtils;

// Classes of messages of program.
public static class SystemMessages
{
    public const string ExitPoint = "Press Q to finish | Press any other key to continue";
    public const string BeforePathGetting = "Type absolute path";
    public const string MenuChoices = "Menu:\n" + 
                                      "1. Select by CoverageArea\n" +
                                      "2. Select by ParkName\n" +
                                      "3. Select by AdmArea and CoverageArea\n" +
                                      "4. Sort by Name (alphabetical order)\n" +
                                      "5. Sort by CoverageArea (increasing order)\n" +
                                      "6. Close and save current file\n" +
                                      "7. Close current file !without save!";
}

public static class ErrorMessages
{
    public const string PathError = "Path error";
    public const string MenuTypeError = "Menu type error";
    public const string MenuAreaError = "Menu area error";
    public const string CustomOpenFileError = "File not found or file contains incorrect data";
    public const string UnexpectedError = "Unexpected error occured";
    public const string NotFullPathError = "Path is not absolute";
    public const string WrongPathWhileReadError = "Incorrect path";
    public const string WrongRemakeData = "Error in remake data";
    public const string DataRefactorError = "Error in refactor data";
    
    public const string WrongCoverageAreaChoosing = "Error in choosing by CoverageArea";
    public const string WrongParkNameChoosing = "Error in choosing by Name";
    public const string WrongAdmAndCoverageAreaChoosing = "Error in choosing by AdmArea and CoverageArea";
    public const string WrongNameSorting = "Error in sorting by Name";
    public const string WrongCoverageAreaSorting = "Error in sorting by CoverageArea";
}