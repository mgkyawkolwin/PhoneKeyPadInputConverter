using System.Text.RegularExpressions;

namespace BasicConverter;

/// <summary>
/// Basic interpreter class for phone keypad input.
/// </summary>
public static class BasicRecursiveConverter 
{

    /// <summary>
    /// Basic interpreter method for phone keypad input.
    /// </summary>
    /// <param name="input">Phone keypad input.</param>
    /// <returns>Interpreted string result.</returns>

    public static string OldPhonePadWithRecursion(string input)
    {

        // replace backspace and digit before anything
        input = Regex.Replace(input, Helper.BackspacePattern, "");
        
        if(String.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException(nameof(input), "Input should not be null or empty.");
            
        if(!Helper.RegEx.IsMatch(input))
            throw new FormatException("Input format is wrong.");

        return Convert(input, "");
    }

    /// <summary>
    /// Internal conversion function which actually interpret the input.
    /// </summary>
    /// <param name="input">Phone keypad input.</param>
    /// <param name="block">Uninterpreted pending block of numbers for grouping.</param>
    /// <returns>Interpreted string result.</returns>
    private static string Convert(string input, string block) 
    {
        string converted = "";
        var fChar = input[0];
        char sChar;
        block += fChar;

        // found space, no process, proceed next
        if(fChar == ' ')
            return Convert(input[1..], "");

        // last char, convert and return
        if(input.Length == 2)
            return Helper.ConversionDict[block];

        if(input.Length >= 3)
        {
            sChar = input[1];
            // match char found, look for grouping
            if(fChar == sChar)
                converted += Convert(input[1..], block);
            else
            {
                // char differ, can covert
                converted = Helper.ConversionDict[block];
                converted += Convert(input[1..], "");
            }
        }
        return converted;
    }

}