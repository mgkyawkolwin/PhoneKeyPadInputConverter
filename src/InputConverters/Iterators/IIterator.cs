namespace InputConverters.Iterators;

/// <summary>
/// Generic interface of iterator alike chain of command interface.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IIterator<T> 
{
    /// <summary>
    /// Add next object in the chain.
    /// </summary>
    /// <param name="next"></param>
    /// <returns></returns>
    T AddNext(T next);

    /// <summary>
    /// Should return True if there is next item in the chain, otherwise False.
    /// </summary>
    /// <returns>True if there is next item, else False.</returns>
    bool HasNext();

    /// <summary>
    /// Return next item in the chain.
    /// </summary>
    /// <returns></returns>
    T Next();
}