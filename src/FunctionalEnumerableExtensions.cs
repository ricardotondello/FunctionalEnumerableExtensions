namespace FunctionalEnumerableExtensions;

public static class FunctionalEnumerableExtensions
{
    /// <summary>
    /// Prevent memory allocation, suitable for .ToList() LINQ.
    /// </summary>
    /// <param name="xs">Enumerable to be converted</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>Cast the list for its type</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static List<T> EnsureList<T>(this IEnumerable<T> xs)
    {
        if (xs == null)
        {
            throw new ArgumentNullException(nameof(xs), "is null");
        }

        var list = xs as List<T> ?? xs.ToList();

        return list;
    }

    /// <summary>
    /// Prevent memory allocation, suitable for .ToArray() LINQ.
    /// </summary>
    /// <param name="xs">Enumerable to be converted</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>Cast the list for its type</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static T[] EnsureArray<T>(this IEnumerable<T> xs)
    {
        if (xs == null)
        {
            throw new ArgumentNullException(nameof(xs), "is null");
        }

        var array = xs as T[] ?? xs.ToArray();

        return array;
    }

    /// <summary>
    /// Warning: DO NOT use Span if you would change the list while looping into it, it can cause exceptions 
    /// </summary>
    /// <param name="xs">Enumerable to be converted</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>return a Span of your list</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Span<T> AsSpan<T>(this IEnumerable<T> xs)
    {
        if (xs == null)
        {
            throw new ArgumentNullException(nameof(xs), "is null");
        }

        var list = xs.EnsureArray();
        return new Span<T>(list);
    }
}