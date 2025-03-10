# PhoneKeyPadInputConverter
Input converter which converts the numerical key inputs from old phone keypad into alphanumeric characters.

### What is PhoneKeyPadInputConverter?

PhoneKeyPadInputConverter is a library which accepts input from old keypad phone and convert it into human readable characters and sentences.

Example: 
User inputs 222 2 22# and converter converts it to the word "CAB".

### About the source code
Source code contains two proejct for different converters, BasicConverters and InputConverters. BasicConverters project contain utility/helper style classes which use normal loop/recursive to convert the input. InputConverters is a class library style project with classes such as factory, interpreter and validator. You can import the project and use directly or you can extend it if you need which is not already available. 

### How do I get started?
You can download the entire souce code to build and run yourself from here.
[GitHub Repository Code](https://github.com/mgkyawkolwin/PhoneKeypadInputConverter)

Or you can download the latest release from here.
[Latest Releases](https://github.com/mgkyawkolwin/PhoneKeypadInputConverter/releases)

First, you need to import the project and use this namespace.

```csharp
using InputConverters.Converter;
```

Then you can create the converter from the factory and use it.

```csharp
// first create a sanitizer to do basic sanitization
var sanitizer = KeyPadConverterFactory.CreateSanitizer(input);
// Process() will do some fundamental validation and then convert to intermediate result
var sanitizedInput = sanitizer.Process();
// After you sanitized, then pass it to the factory to create the actual converter
var converter = KeyPadConverterFactory.Create(sanitizedInput);
// This will produces the final converted result.
return converter.Process();
```

### Do you have an issue?

If you have any issues, you may log the issue [HERE](https://github.com/mgkyawkolwin/PhoneKeypadInputConverter/issues).