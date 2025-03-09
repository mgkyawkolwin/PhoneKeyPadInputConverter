namespace InputConverters.Common;

/// <summary>
/// Regular expression patterns.
/// </summary>
public static class RegexPatterns
{

    /// <summary>
    /// Regular expression pattern for a digit followd by backspace character.
    /// </summary>
    public static readonly string BackspacePattern = @"\d\*";

    /// <summary>
    /// Regular expression pattern for phone keypad input validation.
    /// </summary>
    public static readonly string InterpreterPattern = @"^(?!([7|9])\1{4})(?!([2-68])\2{3})(?!1)[2-9]([ 2-9\*]+)*#$";

}