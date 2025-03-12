using System.Text.RegularExpressions;

using InputConverters.Common;
using InputConverters.Interpreters;
using InputConverters.Validators;

namespace InputConverters.Converters.KeyPadConverter;

/// <summary>
/// Static factory class which build and return KeyPadConverter intance and return.
/// </summary>
public static class KeyPadConverterFactory
{
    /// <summary>
    /// Static factory method which build and return KeyPadConverter intance and return.
    /// </summary>
    /// <param name="input">Text to be interpreted.</param>
    /// <returns>Instance of a KeyPadConverter class.</returns>
    public static KeyPadConverter Create(string input)
    {

        // prepare validator
        var validator = new Validator(input, () => new ArgumentNullException("Input should not be null."), (x) => x != null);
        validator.AddNext(new Validator(input, () => new ArgumentException("Input should not be empty."), (x) => !String.IsNullOrWhiteSpace(x)))
        .AddNext(new Validator(input, () => new FormatException("Input is not in correct format."), (x) => Regex.IsMatch(x, RegexPatterns.InterpreterPattern)));

        // Prepare interpreters.
        // Rules for backspace \* and # should come first
        // Rules should be added from larger no of characters to fewest characters.
        // space rule should come last
        var interpreter = new Interpreter((x) => Regex.Replace(x,@"(\d\*)|( \*)", "", RegexOptions.IgnoreCase));
        interpreter.AddNext(new Interpreter((x) => x.Replace("#", "")))// Backspace rule
        .AddNext(new Interpreter((x) => x.Replace("222", "C"))) //largest characters in a character group
        .AddNext(new Interpreter((x) => x.Replace("22", "B"))) //fewer characters in a character group
        .AddNext(new Interpreter((x) => x.Replace("2", "A"))) //fewest character in a character group
        .AddNext(new Interpreter((x) => x.Replace("333", "F")))
        .AddNext(new Interpreter((x) => x.Replace("33", "E")))
        .AddNext(new Interpreter((x) => x.Replace("3", "D")))
        .AddNext(new Interpreter((x) => x.Replace("444", "I")))
        .AddNext(new Interpreter((x) => x.Replace("44", "H")))
        .AddNext(new Interpreter((x) => x.Replace("4", "G")))
        .AddNext(new Interpreter((x) => x.Replace("555", "L")))
        .AddNext(new Interpreter((x) => x.Replace("55", "K")))
        .AddNext(new Interpreter((x) => x.Replace("5", "J")))
        .AddNext(new Interpreter((x) => x.Replace("666", "O")))
        .AddNext(new Interpreter((x) => x.Replace("66", "N")))
        .AddNext(new Interpreter((x) => x.Replace("6", "M")))
        .AddNext(new Interpreter((x) => x.Replace("7777", "S")))
        .AddNext(new Interpreter((x) => x.Replace("777", "R")))
        .AddNext(new Interpreter((x) => x.Replace("77", "Q")))
        .AddNext(new Interpreter((x) => x.Replace("7", "P")))
        .AddNext(new Interpreter((x) => x.Replace("888", "V")))
        .AddNext(new Interpreter((x) => x.Replace("88", "U")))
        .AddNext(new Interpreter((x) => x.Replace("8", "T")))
        .AddNext(new Interpreter((x) => x.Replace("9999", "Z")))
        .AddNext(new Interpreter((x) => x.Replace("999", "Y")))
        .AddNext(new Interpreter((x) => x.Replace("99", "X")))
        .AddNext(new Interpreter((x) => x.Replace("9", "W")))
        .AddNext(new Interpreter((x) => x.Replace(" ", "")));// space rule


        return new KeyPadConverter(validator, interpreter, input);
    }
    /// <summary>
    /// Static factory method to sanitize input and handle backspace before doing actual conversion.
    /// </summary>
    /// <param name="input">Text to be interpreted.</param>
    /// <returns>Instance of a KeyPadConverter class.</returns>
    public static KeyPadConverter CreateSanitizer(string input)
    {

        // prepare validator
        Validator validator = new (input, () => new ArgumentNullException("Input should not be null."), (x) => x != null);
        validator.AddNext(new Validator(input, () => new ArgumentException("Input should not be empty."), (x) => !String.IsNullOrWhiteSpace(x)));

        // Prepare interpreters.
        // Rules for backspace \* and # should come first
        // Rules should be added from larger no of characters to fewest characters.
        // space rule should come last
        var interpreter = new Interpreter((x) => 
        {
            while(x.Contains('*')) 
            {
                x = Regex.Replace(x,@"(\d\*)|( \*)", "", RegexOptions.IgnoreCase);
            }
            return x;
        });


        return new KeyPadConverter(validator, interpreter, input);
    }
}