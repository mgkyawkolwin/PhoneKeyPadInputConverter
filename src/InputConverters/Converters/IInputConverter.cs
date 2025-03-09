
namespace InputConverters.Converters;

/// <summary>
/// Interface for interpreting the phone keypad input.
/// </summary>
public interface IInputConverter 
{
    /// <summary>
    /// Process the interpretation.
    /// </summary>
    /// <returns>Interpreted string.</returns>
    string Process();

}