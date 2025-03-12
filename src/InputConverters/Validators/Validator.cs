namespace InputConverters.Validators;

/// <summary>
/// Validator for the phone keypad input text.
/// </summary>
public class Validator : IValidator
{
    private readonly Func<Exception> _exception;
    private readonly string _input;
    private IValidator? _next;
    private readonly Func<string, bool> _rule;

    public Validator(string input, Func<Exception> exception, Func<string, bool> rule)
    {
        _exception = exception;
        _input = input;
        _rule = rule;
    }

    /// <summary>
    /// Add next validator in the chain.
    /// </summary>
    /// <param name="next">Next validator.</param>
    /// <returns>Next validator.</returns>
    public IValidator AddNext(IValidator next)
    {
        return _next = next;
    }

    /// <summary>
    /// Check whether there is next validator in the chain.
    /// </summary>
    /// <returns>True if there is next validator, otherwise return False.</returns>
    public bool HasNext() 
    {
        return _next != null;
    }

    /// <summary>
    /// Get next validator in the chain.
    /// </summary>
    /// <returns>Next validator.</returns>
    public IValidator Next() 
    {
        return _next;
    }

    /// <summary>
    /// Validate the input based on the provided rule.
    /// If there are next validator, call Validate() method of next validator.
    /// </summary>
    /// <exception>ArgumentNullExcepton, InvalidArgumentException, FormatException.</exception>
    public void Validate()
    {
        if(!_rule(_input))
            throw _exception();
        else if(HasNext())
            _next.Validate();
    }


}