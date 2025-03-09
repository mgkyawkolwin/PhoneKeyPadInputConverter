using System.Text.RegularExpressions;

namespace BasicConverter;

/// <summary>
/// Helper class for basic converters.
/// </summary>
public static partial class Helper 
{

    public static readonly string BackspacePattern = @"\d\*";

    public static readonly Dictionary<string,string> ConversionDict = new ()
    {
        {"2", "A"},{"22", "B"},{"222", "C"},{"3", "D"},{"33", "E"},{"333", "F"},
        {"4", "G"},{"44", "H"},{"444", "I"},{"5", "J"},{"55", "K"},{"555", "L"},
        {"6", "M"},{"66", "N"},{"666", "O"},{"7", "P"},{"77", "Q"},{"777", "R"},
        {"7777", "S"},{"8", "T"},{"88", "U"},{"888", "V"},{"9", "W"},{"99", "X"},
        {"999", "Y"},{"9999", "Z"}
    };

    [GeneratedRegex(@"^(?!([7|9])\1{4})(?!([2-68])\2{3})(?!1)[2-9]([ 2-9\*]+)*#$")]
    public static partial Regex RegEx{get;}
}