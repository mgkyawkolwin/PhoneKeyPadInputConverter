using InputConverters.Converters.KeyPadConverter;

namespace UnitTests;

[TestClass]
public sealed class Test1
{

    [TestMethod]
    [DataRow("2222*#", "222#")]
    [DataRow("22222 2222**#", "22222 22#")]
    [DataRow("3 33***#", "3#")]
    public void Factory_CreateSanitizer_Should_Return_Complete_Sanitizer(string input, string expected)
    {
        var sanitizer = KeyPadConverterFactory.CreateSanitizer(input);
        var result = sanitizer.Process();

        Assert.AreEqual(expected, result);
    }


    [TestMethod]
    [DataRow("2#", "A")]
    [DataRow("22#", "B")]
    [DataRow("227*#", "B")]
    [DataRow("222#", "C")]
    [DataRow("3#", "D")]
    [DataRow("33#", "E")]
    [DataRow("333#", "F")]
    [DataRow("222 2 22#", "CAB")] 
    [DataRow("4433555 555666#", "HELLO")]
    [DataRow("8 88777444666*4#", "TURING")]
    [DataRow("8 887774446 *64#", "TURING")]
    [DataRow("8 88777444666*4#", "TURING")]
    [DataRow("8 8877744466 *4#", "TURING")]
    [DataRow("2 22 222 3 33 333 4 44 444 5 55 555 6 66 666 7 77 777 7777 8 88 888 9 99 999 9999#", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
    public void Factory_Create_Should_Return_Complete_Converter(string input, string expected)
    {
        var sanitizer = KeyPadConverterFactory.CreateSanitizer(input);
        var sanitizedInput = sanitizer.Process();
        Console.WriteLine(sanitizedInput);
        var converter = KeyPadConverterFactory.Create(sanitizedInput);
        var result = converter.Process();

        Assert.AreEqual(expected, result);
    }
}
