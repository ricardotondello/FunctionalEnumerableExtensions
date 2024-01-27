namespace FunctionalEnumerableExtensions;

public static class FunctionalEnumerableExtensions
{
    /// <summary>
    /// Prevent memory allocation, suitable for .ToList() LINQ.
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="TSource">Type of your source</typeparam>
    /// <returns>Cast the list for its type</returns>
    public static List<TSource> EnsureList<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            return new List<TSource>();
        }

        var list = enumerable as List<TSource> ?? enumerable.ToList();

        return list;
    }

    /// <summary>
    /// Prevent the enumerable to be null
    /// </summary>
    /// <param name="enumerable">Enumerable to be checked for null</param>
    /// <typeparam name="TSource">Type of your enumerable</typeparam>
    /// <returns>A empty Enumerable if null otherwise the enumerable itself</returns>
    public static IEnumerable<TSource> EnsureEnumerable<TSource>(this IEnumerable<TSource>? enumerable)
    {
        return enumerable ?? Enumerable.Empty<TSource>();
    }

    /// <summary>
    /// Prevent memory allocation, suitable for .ToArray() LINQ.
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="TSource">Type of your source</typeparam>
    /// <returns>Cast the list for its type</returns>
    public static TSource[] EnsureArray<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            return Array.Empty<TSource>();
        }

        var array = enumerable as TSource[] ?? enumerable.ToArray();

        return array;
    }

    /// <summary>
    /// Prevent memory allocation, convert the enumerable to a HashSet, avoiding duplications
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="TSource">Type of your source</typeparam>
    /// <returns>Cast or return a HashSet list for its type</returns>
    public static HashSet<TSource> EnsureHashSet<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            return new HashSet<TSource>();
        }

        return enumerable as HashSet<TSource> ?? new HashSet<TSource>(enumerable);
    }

    /// <summary>
    /// Warning: DO NOT use Span if you would change the list while looping into it, it can cause exceptions 
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="TSource">Type of your source</typeparam>
    /// <returns>return a Span of your list</returns>
    public static Span<TSource> AsSpan<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            return new Span<TSource>();
        }

        var list = enumerable.EnsureArray();
        return new Span<TSource>(list);
    }

    /// <summary>
    /// Filter the non nulls items in the enumerable provided
    /// </summary>
    /// <param name="enumerable">Enumerable to be filtered</param>
    /// <typeparam name="TSource">Type of your source</typeparam>
    /// <returns>Returns the enumerable filtered</returns>
    public static IEnumerable<TSource> CollectNonNulls<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            return Enumerable.Empty<TSource>();
        }

        var result = enumerable.Where(o => o != null);

        return result;
    }

    /// <summary>
    /// Splits the list according to the predicate
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <param name="predicate">Condition to be applied</param>
    /// <typeparam name="TSource">Type of your source</typeparam>
    /// <returns>A Tuple with DesiredItems that matches the predicate and RemainingItems that doesnt matches the predicate</returns>
    public static (IEnumerable<TSource> DesiredItems, IEnumerable<TSource> RemainingItems) SplitBy<TSource>(
        this IEnumerable<TSource>? enumerable, Func<TSource, bool> predicate)
    {
        if (enumerable == null)
        {
            return (Enumerable.Empty<TSource>(), Enumerable.Empty<TSource>());
        }

        var groups = enumerable
            .GroupBy(predicate)
            .ToArray();

        var desiredItems = groups
            .Where(w => w.Key)
            .SelectMany(s => s);

        var remainingItems = groups
            .Where(w => !w.Key)
            .SelectMany(s => s);

        return (desiredItems, remainingItems);
    }

    /// <summary>
    /// Checks if the list is null or empty
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <typeparam name="TSource">Type of your source</typeparam>
    /// <returns>`True` if null or Empty, otherwise `false`</returns>
    public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource>? enumerable)
    {
        return enumerable == null || !enumerable.Any();
    }

    /// <summary>
    /// Optional filtering criteria, Avoids if statements when building predicates & lambdas for a query
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <param name="condition">Boolean</param>
    /// <param name="predicate">Where condition to be apply if condition is true, otherwise the enumerable</param>
    /// <typeparam name="TSource">Type of your source</typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource>? enumerable, bool condition,
        Func<TSource, bool> predicate)
    {
        if (enumerable == null)
        {
            return Enumerable.Empty<TSource>();
        }

        return condition ? enumerable.Where(predicate) : enumerable;
    }
}