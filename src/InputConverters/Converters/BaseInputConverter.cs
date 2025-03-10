

namespace InputConverters.Converters;

/// <summary>
/// Base class for interpreting phone keypad input.
/// </summary>
public abstract class BaseInputConverter : IInputConverter
{

    /// <summary>
    /// Abstract method to interpret the phone keypad input.
    /// </summary>
    /// <returns>Interpreted text.</returns>
    protected abstract string Interpret();

    public string Process()
    {
        Validate();
        return Interpret();
    }

    /// <summary>
    /// Abstract method to validate the phone keypad input.
    /// </summary>
    protected abstract void Validate();
}