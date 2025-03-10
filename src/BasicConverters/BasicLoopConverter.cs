using System.Text.RegularExpressions;

namespace BasicConverters;

/// <summary>
/// Basic interpreter class for phone keypad input.
/// </summary>
public static class BasicLoopConverter 
{

    /// <summary>
    /// Basic interpreter method for phone keypad input.
    /// </summary>
    /// <param name="input">Phone keypad input.</param>
    /// <returns>Interpreted string result.</returns>
    public static string OldPhonePadWithLoop(string input)
    {
        while(input.Contains('*', StringComparison.OrdinalIgnoreCase))
        {
            // replace backspace and digit before anything
            input = Helper.BackspaceRegEx.Replace(input, "");Console.WriteLine(input);
        }
        
        if(String.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException(nameof(input), "Input should not be null or empty.");

        if(!Helper.InterpretRegEx.IsMatch(input))
            throw new FormatException("Input format is wrong.");

        
        

        var converted = "";
        var block = "";

        for (var x = 0; x < input.Length; x++)
        {
            var fChar = input[x]; 
            // found #, conversion complete
            if(fChar == '#')
                break;
            // already converted before, continue
            if(fChar == ' ')
                continue;
            block += fChar;
            var sChar = input[x+1];
            // found a space, can convert now
            if(sChar == ' ')
            {
                converted += Helper.ConversionDict[block];
                block = "";
                continue;
            }
            // same char, wait for next loop
            if(fChar == sChar)
                continue;
            // different char, can convert now
            if(fChar != sChar)
            {
                converted += Helper.ConversionDict[block];
                block = "";
            }
            
        }
        
        return converted;
    }
}