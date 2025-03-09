using System.Text.RegularExpressions;

using InputConverters.Interpreters;

namespace Tests.UnitTests;

[TestClass]
public sealed class InterpreterTest
{
    [TestMethod]
    public void Interpreter_Should_Fail()
    {
        NullReferenceException exception = Assert.ThrowsException<NullReferenceException>(
            () => new Interpreter((x) => x.Replace("222", "B")).Interpret(null)
        );
    }


    [TestMethod]
    [DataRow("2","A", "A")]
    [DataRow("22","B", "B")]
    [DataRow("222","C", "C")]
    public void Interpreter_Single_Rule_Should_Success(string input, string replace, string expected)
    {
        var result = new Interpreter((x) => x.Replace(input, replace)).Interpret(input);

        Assert.AreEqual(expected, result);
    }


    [TestMethod]
    [DataRow("2", "A")]
    [DataRow("22", "B")]
    [DataRow("227*", "B")]
    [DataRow("222", "C")]
    [DataRow("3", "D")]
    [DataRow("33", "E")]
    [DataRow("333", "F")]
    [DataRow("222 2 22", "CAB")]
    [DataRow("4433555 555666", "HELLO")]
    [DataRow("8 88777444666*664", "TURIOMG")]
    [DataRow("2 22 222 3 33 333 4 44 444 5 55 555 6 66 666 7 77 777 7777 8 88 888 9 99 999 9999", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
    public void Interpreter_Complete_Rules_Should_Success(string input, string expected)
    { 
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



        var result = interpreter.Interpret(input);

        Assert.AreEqual(expected, result);
    }
}