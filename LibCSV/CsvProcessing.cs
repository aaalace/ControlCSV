using System.Text;
using LibUtils;

namespace LibCSV;

public static class CsvProcessing
{
    private static string fPath = string.Empty;

    // Custom exceptions
    private class WrongStructureException : Exception { }
    private class NotFullPathException : Exception { }

    public static string[] Read(in string path, out int dataStatus)
    {
        string[] initArray = Array.Empty<string>();
        dataStatus = ConstantItems.StatusOk;
        fPath = path;

        try
        {
            try
            {
                // If ReadAllLines throws FileNotFoundEx -> throws ArgumentNullEx.
                initArray = File.ReadAllLines(fPath, encoding: Encoding.UTF8);

                // If input path != GetFullPath, but input path exists, then it is not full path.
                if (fPath != Path.GetFullPath(fPath))
                {
                    throw new NotFullPathException();
                }

                // If file structure is incorrect -> throws WrongStructureEx -> throws ArgumentNullEx.
                if (!CheckFileStructure(initArray))
                {
                    throw new WrongStructureException();
                }
            }
            catch (WrongStructureException)
            {
                throw new ArgumentNullException();
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentNullException();
            }
            catch (NotFullPathException)
            {
                dataStatus = ConstantItems.StatusError;
                ConsoleInteraction.MessagesWriter(ErrorMessages.NotFullPathError, 2);
            }
            catch (ArgumentException)
            {
                dataStatus = ConstantItems.StatusError;
                ConsoleInteraction.MessagesWriter(ErrorMessages.WrongPathWhileReadError, 2);
            }
            catch (Exception)
            {
                dataStatus = ConstantItems.StatusError;
                ConsoleInteraction.MessagesWriter(ErrorMessages.UnexpectedError, 2);
            }
        }
        catch (ArgumentNullException)
        {
            dataStatus = ConstantItems.StatusError;
            ConsoleInteraction.MessagesWriter(ErrorMessages.CustomOpenFileError, 2);
        }

        return initArray;
    }

    public static void Write(string[] data)
    {
        try
        {
            File.WriteAllText(fPath, string.Empty);
            File.WriteAllLines(fPath, contents: data);
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WriteError, 2);
        }
    }

    public static void Write(string strData, string nPath, bool beenExits = false)
    {
        try
        {
            if (beenExits)
            {
                using StreamWriter file = new(nPath, append: true);
                file.WriteLine(strData);
                return;
            }
            string[] remadeArr = new string[3];
            string[] helpWithEn = new string[ConstantItems.initHeadRowEn.Length];
            string[] helpWithRu = new string[ConstantItems.initHeadRowRu.Length];
            for (int i = 0; i < helpWithEn.Length; i++)
            {
                helpWithEn[i] = '"' + ConstantItems.initHeadRowEn[i] + '"';
                helpWithRu[i] = '"' + ConstantItems.initHeadRowRu[i] + '"';
            }
            remadeArr[0] = string.Join(';', helpWithEn) + ";";
            remadeArr[1] = string.Join(';', helpWithRu) + ";";
            remadeArr[2] = strData;
            File.WriteAllLines(nPath, contents: remadeArr);
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.WriteError, 2);
        }
    }

    // 1) Not only headers in csv; 2) Headers structure correct; 3) Number of elements in row correct.
    private static bool CheckFileStructure(string[] arr)
    {
        if (arr.Length < 2)
        {
            return false;
        }

        string[] headRowEn = arr[0].Split(';').Where(x => !string.IsNullOrEmpty(x)).ToArray();
        string[] headRowRu = arr[1].Split(';').Where(x => !string.IsNullOrEmpty(x)).ToArray();
        int rowLen = headRowEn.Length;

        for (int i = 0; i < rowLen; i++)
        {
            string trimRowEn = headRowEn[i].Trim(new[] { '"' });
            string trimRowRu = headRowRu[i].Trim(new[] { '"' });

            if (trimRowEn != ConstantItems.initHeadRowEn[i] |
                trimRowRu != ConstantItems.initHeadRowRu[i])
            {
                return false;
            }
        }

        return arr[2..].Select(row => row.Split(';').Where(x =>
            !string.IsNullOrEmpty(x)).ToArray()).All(timedArr => timedArr.Length == rowLen);
    }

    // Remake string[] to string[][]; 
    public static string[][] RemakeData(in string[] arr, out int remakeStatus)
    {
        string[][] remadeArr = Array.Empty<string[]>();
        remakeStatus = ConstantItems.StatusOk;

        try
        {
            string[] noHeadersArr = arr[2..];
            remadeArr = new string[noHeadersArr.Length][];
            for (int i = 0; i < noHeadersArr.Length; i++)
            {
                string[] timedArr = noHeadersArr[i].Split(';')[..^1];
                for (int j = 0; j < timedArr.Length; j++)
                {
                    timedArr[j] = timedArr[j].Trim(new[] { '"' });
                }
                remadeArr[i] = timedArr;
            }
        }
        catch (Exception)
        {
            remakeStatus = ConstantItems.StatusError;
            ConsoleInteraction.MessagesWriter(ErrorMessages.WrongRemakeData, 2);
        }

        return remadeArr;
    }

    // Remake string[][] to string[]; 
    public static string[] RemakeDataBack(in string[][] arr, out int remakeBackStatus)
    {
        string[] remadeArr = Array.Empty<string>();
        remakeBackStatus = ConstantItems.StatusOk;

        try
        {
            remadeArr = new string[arr.Length + 2];

            string[] helpWithEn = new string[ConstantItems.initHeadRowEn.Length];
            string[] helpWithRu = new string[ConstantItems.initHeadRowRu.Length];
            for (int i = 0; i < helpWithEn.Length; i++)
            {
                helpWithEn[i] = '"' + ConstantItems.initHeadRowEn[i] + '"';
                helpWithRu[i] = '"' + ConstantItems.initHeadRowRu[i] + '"';
            }
            remadeArr[0] = string.Join(';', helpWithEn) + ";";
            remadeArr[1] = string.Join(';', helpWithRu) + ";";

            for (int i = 2; i < remadeArr.Length; i++)
            {
                string[] timedArr = new string[arr[i - 2].Length];
                for (int j = 0; j < timedArr.Length; j++)
                {
                    timedArr[j] = '"' + arr[i - 2][j] + '"';
                }
                remadeArr[i] = string.Join(';', timedArr) + ";";
            }
        }
        catch (Exception)
        {
            ConsoleInteraction.MessagesWriter(ErrorMessages.UnexpectedError, 2);
            remakeBackStatus = ConstantItems.StatusOk;
        }

        return remadeArr;
    }
}
