﻿namespace LibUtils;

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

    public static readonly ConsoleColor[] CellColors =
    {
        ConsoleColor.DarkGreen,
        ConsoleColor.DarkYellow,
        ConsoleColor.DarkBlue,
        ConsoleColor.DarkMagenta,
        ConsoleColor.DarkRed,
    };

    public const int StopMenuAndSaveOption = 6;
    
    public static string[] initHeadRowEn = {"ID", "global_id", "Name", "AdmArea", "District", "ParkName", 
        "WiFiName", "CoverageArea", "FunctionFlag", "AccessFlag", "Password", "Longitude_WGS84", "Latitude_WGS84", 
        "geodata_center", "geoarea"};
    public static string[] initHeadRowRu = {"Код", "global_id", "Наименование", "Административный округ по адресу", 
        "Район", "Наименование парка", "Имя Wi-Fi сети", "Зона покрытия (метры)", "Признак функционирования", 
        "Условия доступа", "Пароль", "Долгота в WGS-84", "Широта в WGS-84", "geodata_center", "geoarea"};
}