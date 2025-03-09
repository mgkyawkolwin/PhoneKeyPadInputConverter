using BasicConverter;
using InputConverters.Converters.KeyPadConverter;


static string OldPhonePad(string input ) 
{
    var converter = KeyPadConverterFactory.Create(input);
    return converter.Process();
}


Console.Clear();
Console.WriteLine("OldPhoneKeyPadInputConverter");
Console.WriteLine("============================");
Console.WriteLine("Please type in for your input. Valid characters are 23456789 and non-consecutive space.");
Console.WriteLine("You cannot enter each number more than three times consecutively.");
Console.WriteLine("Sample inputs: 2# => A. 22# => B, 222# => C, 222 2 22# => CAB, 4433555 555666# => HELLO");
Console.WriteLine("If you want to exit, please type \"exit\".");
Console.WriteLine();

do 
{
    Console.WriteLine("Please enter your input!");
    var result = "";
    var input = Console.ReadLine();

    if (String.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
       break;

    if(string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Invalid input. Please type number and space only.");
        continue;
    }

    Console.WriteLine("Please choose the method to use.");
    Console.WriteLine("1 => OOP, 2 => Loop, 3 => Recursive");
    var method = Console.ReadLine();

    try
    {
        if( String.Equals(method?.Trim(), "1")) 
        {
            result = OldPhonePad(input);
        }
        else if(String.Equals(method?.Trim(), "2")) 
        {
            result = BasicLoopConverter.OldPhonePadWithLoop(input);
        }
        else if(String.Equals(method?.Trim(), "3")) 
        {
            result = BasicRecursiveConverter.OldPhonePadWithRecursion(input);
        }
        else
        {
            Console.WriteLine("Invalid method. Please try again.");
            continue;
        }
        Console.WriteLine("Converted string is : " + result);
        Console.WriteLine();
    }
    catch(ArgumentNullException)
    {
        Console.WriteLine("Please type in some values.");
    }
    catch(FormatException)
    {
        Console.WriteLine("Input format is wrong.");
    }
    catch
    {
        Console.WriteLine("Unknown error occured. Please try again.");
    }

    

    
}while(true);

Console.WriteLine("Program exited.");






