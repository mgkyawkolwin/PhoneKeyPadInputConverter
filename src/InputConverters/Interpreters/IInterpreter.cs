using InputConverters.Iterators;

namespace InputConverters.Interpreters;

/// <summary>
/// Interface for interpreting phone keypad input into corresponding characters. 
/// </summary>
public interface IInterpreter : IIterator<IInterpreter>
{
    /// <summary>
    /// Implement to interpret phone keypad input into corresponding characters.
    /// </summary>
    /// <param name="input">Phone keypad input.</param>
    /// <returns>Interpreted string.</returns>
    string Interpret(string input);
}