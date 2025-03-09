using System.Text.RegularExpressions;

using InputConverters.Common;
using InputConverters.Interpreters;
using InputConverters.Validators;

namespace InputConverters.Converters.KeyPadConverter;

public static class KeyPadConverterFactory
{
    public static KeyPadConverter Create(string input)
    {
        // prepare validator
        Validator validator = new (input, () => new ArgumentNullException("Input should not be null."), (x) => x != null);
        validator.AddNext(new Validator(input, () => new ArgumentException("Input should not be empty."), (x) => !String.IsNullOrWhiteSpace(x)))
        .AddNext(new Validator(input, () => new FormatException("Input is not in correct format."), (x) => Regex.IsMatch(x, RegexPatterns.InterpreterPattern)));

        // Prepare interpreters.
        // Rules for backspace \* and # should come first
        // Rules should be added from larger no of characters to fewer characters.
        var interpreter = new Interpreter((x) => Regex.Replace(x,@"\d\*", "", RegexOptions.IgnoreCase));
        interpreter.AddNext(new ((x) => x.Replace("#", "")))
        .AddNext(new ((x) => x.Replace("222", "C")))
        .AddNext(new ((x) => x.Replace("22", "B")))
        .AddNext(new ((x) => x.Replace("2", "A")))
        .AddNext(new ((x) => x.Replace("333", "F")))
        .AddNext(new ((x) => x.Replace("33", "E")))
        .AddNext(new ((x) => x.Replace("3", "D")))
        .AddNext(new ((x) => x.Replace("444", "I")))
        .AddNext(new ((x) => x.Replace("44", "H")))
        .AddNext(new ((x) => x.Replace("4", "G")))
        .AddNext(new ((x) => x.Replace("555", "L")))
        .AddNext(new ((x) => x.Replace("55", "K")))
        .AddNext(new ((x) => x.Replace("5", "J")))
        .AddNext(new ((x) => x.Replace("666", "O")))
        .AddNext(new ((x) => x.Replace("66", "N")))
        .AddNext(new ((x) => x.Replace("6", "M")))
        .AddNext(new ((x) => x.Replace("7777", "S")))
        .AddNext(new ((x) => x.Replace("777", "R")))
        .AddNext(new ((x) => x.Replace("77", "Q")))
        .AddNext(new ((x) => x.Replace("7", "P")))
        .AddNext(new ((x) => x.Replace("888", "V")))
        .AddNext(new ((x) => x.Replace("88", "U")))
        .AddNext(new ((x) => x.Replace("8", "T")))
        .AddNext(new ((x) => x.Replace("9999", "Z")))
        .AddNext(new ((x) => x.Replace("999", "Y")))
        .AddNext(new ((x) => x.Replace("99", "X")))
        .AddNext(new ((x) => x.Replace("9", "W")))
        .AddNext(new ((x) => x.Replace(" ", "")));// space rule should come last


        return new KeyPadConverter(validator, interpreter, input);
    }
}