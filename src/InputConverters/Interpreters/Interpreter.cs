namespace InputConverters.Interpreters;

/// <summary>
/// A class responsible for interpreting phone keypad input value into corresponding characters.
/// </summary>
public class Interpreter : IInterpreter
{
    private IInterpreter? _next;
    private readonly Func<string,string> _rule;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="rule">Add rule which will replace the parts of input into corresponding characters.</param>
    public Interpreter(Func<string, string> rule)
    {
        _rule = rule;
    }

    /// <summary>
    /// Add next interpreter into the chain.
    /// </summary>
    /// <param name="next">Next interpreter.</param>
    /// <returns>Next interpreter.</returns>
    public IInterpreter AddNext(IInterpreter next)
    {
        _next = next;
        return _next;
    }

    /// <summary>
    /// Check whether there is next interpreter in the chain.
    /// </summary>
    /// <returns>True if has, else False.</returns>
    public bool HasNext() 
    {
        return _next != null;
    }

    /// <summary>
    /// Interpret the given input based on the current rule.
    /// Pass the interpreted result to next interpreter in the chain if available.
    /// </summary>
    /// <param name="input">Input uninterpreted string.</param>
    /// <returns>Partly or whoely interpreted string.</returns>
    public virtual string Interpret(string input)
    {
        return HasNext() ? _next.Interpret(_rule(input)) : _rule(input);
    }

    /// <summary>
    /// Get next interpreter in the chain.
    /// </summary>
    /// <returns>Next interpreter.</returns>
    public IInterpreter Next() 
    {
        return _next;
    }
}