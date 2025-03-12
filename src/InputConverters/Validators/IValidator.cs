using InputConverters.Iterators;

namespace InputConverters.Validators;

/// <summary>
/// Interface which define the common method for the phone keypad input validation.
/// </summary>
public interface IValidator : IIterator<IValidator>
{
    /// <summary>
    /// Implement to validate the phone keypad input.
    /// Should throw exception if validation fails.
    /// </summary>
    void Validate();
}