namespace LibUtils;

// Classes of messages of program.
public static class SystemMessages
{
    public const string ExitPoint = "press Q to finish | press any other key to continue";
    public const string BeforePathGetting = "type absolute path";
    public const string BeforeMenuChoice = "choose option";
    public const string MenuChoices = "1. ...\n" +
                                      "2. ...\n" +
                                      "3. ...\n" +
                                      "4. ...\n" +
                                      "5. ...\n" +
                                      "6. close and save current file\n" +
                                      "7. close current file (!) without save (!)";
}

public static class ErrorMessages
{
    public const string PathError = "path error";
    public const string MenuTypeError = "menu type error";
    public const string MenuAreaError = "menu area error";
}