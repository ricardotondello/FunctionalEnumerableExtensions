namespace FunctionalEnumerableExtensions;

public static class FunctionalEnumerableExtensions
{
    /// <summary>
    /// Prevent memory allocation, suitable for .ToList() LINQ.
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>Cast the list for its type</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static List<T> EnsureList<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException(nameof(enumerable), "is null");
        }

        var list = enumerable as List<T> ?? enumerable.ToList();

        return list;
    }

    /// <summary>
    /// Prevent memory allocation, suitable for .ToArray() LINQ.
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>Cast the list for its type</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static T[] EnsureArray<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException(nameof(enumerable), "is null");
        }

        var array = enumerable as T[] ?? enumerable.ToArray();

        return array;
    }
    
    /// <summary>
    /// Prevent memory allocation, convert the enumerable to a HashSet, avoiding duplications
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>Cast or return a HashSet list for its type</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static HashSet<T> EnsureHashSet<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException(nameof(enumerable), "is null");
        }

        return enumerable as HashSet<T> ?? new HashSet<T>(enumerable);
    }

    /// <summary>
    /// Warning: DO NOT use Span if you would change the list while looping into it, it can cause exceptions 
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>return a Span of your list</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Span<T> AsSpan<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException(nameof(enumerable), "is null");
        }

        var list = enumerable.EnsureArray();
        return new Span<T>(list);
    }

    /// <summary>
    /// Filter the non nulls items in the enumerable provided
    /// </summary>
    /// <param name="enumerable">Enumerable to be filtered</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>Returns the enumerable filtered</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<T> CollectNonNulls<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException(nameof(enumerable), "is null");
        }

        var result = enumerable.Where(o => o != null);

        return result;
    }
}