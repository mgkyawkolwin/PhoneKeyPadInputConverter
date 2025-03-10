namespace InputConverters.Common;

/// <summary>
/// Regular expression patterns.
/// </summary>
public static class RegexPatterns
{

    /// <summary>
    /// Regular expression pattern for phone keypad input validation.
    /// </summary>
    public static readonly string InterpreterPattern = @"^(?!.*[ ]{2})(?!.*([79])\1{4})(?!.*([2-68])\2{3})(?!.*(\d? #))[2-9]{1}[ 2-9\*]*#$";

}