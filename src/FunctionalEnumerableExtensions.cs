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
        enumerable.ThrowArgumentNullExceptionIfNull();

        var list = enumerable as List<T> ?? enumerable.ToList();

        return list;
    }
    
    /// <summary>
    /// Prevent the enumerable to be null
    /// </summary>
    /// <param name="enumerable">Enumerable to be checked for null</param>
    /// <typeparam name="T">Type of your enumerable</typeparam>
    /// <returns>A empty Enumerable if null otherwise the enumerable itself</returns>
    public static IEnumerable<T> EnsureEnumerable<T>(this IEnumerable<T> enumerable)
    {
        // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
        return enumerable ?? Enumerable.Empty<T>();
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
        enumerable.ThrowArgumentNullExceptionIfNull();

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
        enumerable.ThrowArgumentNullExceptionIfNull();

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
        enumerable.ThrowArgumentNullExceptionIfNull();

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
        enumerable.ThrowArgumentNullExceptionIfNull();
        
        var result = enumerable.Where(o => o != null);

        return result;
    }
    
    /// <summary>
    /// Splits the list according to the predicate
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <param name="predicate">Condition to be applied</param>
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>A Tuple with DesiredItems that matches the predicate and RemainingItems that doesnt matches the predicate</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static (IEnumerable<T> DesiredItems, IEnumerable<T> RemainingItems) SplitBy<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
    {
        enumerable.ThrowArgumentNullExceptionIfNull();
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
    /// <typeparam name="T">Type of your list</typeparam>
    /// <returns>`True` if null or Empty, otherwise `false`</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable)
    {
        return enumerable == null || !enumerable.Any();
    }

    private static void ThrowArgumentNullExceptionIfNull(this object? enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException(nameof(enumerable), "is null");
        }
    }
}