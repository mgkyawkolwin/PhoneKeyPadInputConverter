using System.ComponentModel;
using System.Text.RegularExpressions;

using InputConverters.Common;
using InputConverters.Validators;

namespace UnitTests;

[TestClass]
public sealed class ValidatorTest
{
    [TestMethod]
    public void Validator_Should_Throw_ArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(
            () => new Validator(null, () => new ArgumentNullException("Input should not be null."), (x) => x != null).Validate()
        );
    }

    [TestMethod]
    public void Validator_Should_Throw_InvalidArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(
            () => new Validator("   ", () => new ArgumentException("Input should not be empty."), (x) => !String.IsNullOrWhiteSpace(x)).Validate()
        );
    }

    [TestMethod]
    [DataRow("asdfaf")]
    [DataRow("asdfa  f")]
    [DataRow("2345")]
    [DataRow("234  5")]
    [DataRow("12345#")]
    [DataRow("1234  5#")]
    public void Validator_Should_Throw_FormatException(string input)
    {
        Assert.ThrowsException<FormatException>(
            () => new Validator(input, () => new FormatException("Input is not in correct format."), (x) => Regex.IsMatch(x, RegexPatterns.InterpreterPattern)).Validate()
        );
    }

    [TestMethod]
    [DataRow("2#")]
    [DataRow("22#")]
    [DataRow("222#")]
    [DataRow("2 2#")]
    [DataRow("222 2 22#")]
    [DataRow("22*#")]
    [DataRow("7777*#")]
    [DataRow("9999*#")]
    public void Validator_Should_Pass(string input)
    {
        new Validator(input, () => new FormatException("Input is not in correct format."), (x) => Regex.IsMatch(x, RegexPatterns.InterpreterPattern)).Validate();
    }
}
