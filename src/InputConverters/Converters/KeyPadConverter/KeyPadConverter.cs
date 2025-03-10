
using InputConverters.Interpreters;
using InputConverters.Validators;

namespace InputConverters.Converters.KeyPadConverter;

/// <summary>
/// Class responsible for interpreting the phone keypad into corresponding characters.
/// </summary>
public class KeyPadConverter : BaseInputConverter
{
    private readonly string _input;
    private IValidator _validator;
    private IInterpreter _interpreter;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="validator">Root validator which will perform the first validation in the chain.</param>
    /// <param name="interpreter">Root interpreter which will perform the first interpretation in the chain.</param>
    /// <param name="input">Phone keypad input.</param>
    /// <exception cref="">ArgumentNullException</exception>
    public KeyPadConverter(IValidator validator, IInterpreter interpreter, string input)
    {
        ArgumentNullException.ThrowIfNull(validator);
        ArgumentNullException.ThrowIfNull(interpreter);

        _input = input;
        _interpreter = interpreter;
        _validator = validator;
    }

    /// <summary>
    /// Interpret the phone keypad input.
    /// </summary>
    /// <returns>Interpreted string.</returns>
    protected override string Interpret()
    {
        return _interpreter.Interpret(_input);
    }

    /// <summary>
    /// Validate the phone keypad input.
    /// </summary>
    protected override void Validate()
    {
        _validator.Validate();
    }
}