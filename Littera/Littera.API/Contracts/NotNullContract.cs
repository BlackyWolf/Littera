using System.Runtime.CompilerServices;

namespace Littera.API.Contracts;

/// <summary>
///     The extension class for the NotNull contract method(s).
/// </summary>
public static class NotNullContract
{
    /// <summary>
    ///     Determines if a piece of data is null, and if so, throws an
    ///     exception.
    /// </summary>
    /// <typeparam name="TData">
    ///     The type of data to check for null.
    /// </typeparam>
    /// <param name="data">The data to check for null.</param>
    /// <param name="parameterName">
    ///     An optional parameter name used for better exception messages
    ///     which makes use of
    ///     <see cref="CallerArgumentExpressionAttribute" />.
    /// </param>
    /// <returns>The passed data for method chaining.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if the data is null.
    /// </exception>
    public static TData NotNull<TData>(
        this TData data,
        [CallerArgumentExpression("data")] string parameterName = ""
    )
    {
        return data ?? throw new ArgumentNullException(parameterName);
    }
}