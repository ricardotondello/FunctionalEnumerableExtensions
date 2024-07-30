using System.Collections;

namespace FunctionalEnumerableExtensions;

public static class FunctionalEnumerableExtensions
{
    /// <summary>
    /// Prevent memory allocation, suitable for .ToList() LINQ.
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>Cast the list for its type</returns>
    public static List<TSource> EnsureList<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            // ReSharper disable once UseCollectionExpression
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
    /// <returns>An empty Enumerable if null otherwise the enumerable itself</returns>
    public static IEnumerable<TSource> EnsureEnumerable<TSource>(this IEnumerable<TSource>? enumerable)
    {
        // ReSharper disable once UseCollectionExpression
        return enumerable ?? Enumerable.Empty<TSource>();
    }

    /// <summary>
    /// Prevent memory allocation, suitable for .ToArray() LINQ.
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>Cast the list for its type</returns>
    public static TSource[] EnsureArray<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            // ReSharper disable once UseCollectionExpression
            return Array.Empty<TSource>();
        }

        var array = enumerable as TSource[] ?? enumerable.ToArray();

        return array;
    }

    /// <summary>
    /// Prevent memory allocation, convert the enumerable to a HashSet, avoiding duplications
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>Cast or return a HashSet list for its type</returns>
    public static HashSet<TSource> EnsureHashSet<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            // ReSharper disable once UseCollectionExpression
            return new HashSet<TSource>();
        }

        // ReSharper disable once UseCollectionExpression
        return enumerable as HashSet<TSource> ?? new HashSet<TSource>(enumerable);
    }

    /// <summary>
    /// Warning: DO NOT use Span if you would change the list while looping into it, it can cause exceptions 
    /// </summary>
    /// <param name="enumerable">Enumerable to be converted</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
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
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>Returns the enumerable filtered</returns>
    public static IEnumerable<TSource> CollectNonNulls<TSource>(this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            // ReSharper disable once UseCollectionExpression
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
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>A Tuple with DesiredItems that matches the predicate and RemainingItems that doesn't match the predicate</returns>
    public static (IEnumerable<TSource> DesiredItems, IEnumerable<TSource> RemainingItems) SplitBy<TSource>(
        this IEnumerable<TSource>? enumerable, Func<TSource, bool> predicate)
    {
        if (enumerable == null)
        {
            // ReSharper disable twice UseCollectionExpression
            return (Enumerable.Empty<TSource>(), Enumerable.Empty<TSource>());
        }

        var groups = enumerable.GroupBy(predicate)
            .ToArray();

        var desiredItems = groups.Where(w => w.Key)
            .SelectMany(s => s);

        var remainingItems = groups.Where(w => !w.Key)
            .SelectMany(s => s);

        return (desiredItems, remainingItems);
    }

    /// <summary>
    /// Checks if the list is null or empty
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
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
    /// <param name="predicate">Where condition to be applied if condition is true, otherwise the enumerable</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>The Enumerable when condition is `True` otherwise Empty Enumerable</returns>
    public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource>? enumerable, bool condition,
        Func<TSource, bool> predicate)
    {
        if (enumerable == null)
        {
            // ReSharper disable once UseCollectionExpression
            return Enumerable.Empty<TSource>();
        }

        return condition
            ? enumerable.Where(predicate)
            : enumerable;
    }

    /// <summary>
    /// Iterate the list and executes an actions for each item
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <param name="action">Action to be executed for each item of the list</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    public static void Each<TSource>(this IEnumerable<TSource>? enumerable, Action<TSource> action)
    {
        if (enumerable == null)
        {
            return;
        }

        foreach (var item in enumerable)
        {
            action(item);
        }
    }

    /// <summary>
    /// This method converts a collection of non-null objects to a string by concatenating their properties recursively, separated by commas.
    /// If the input collection is null, an empty string is returned.
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>A string similar to JSON</returns>
    public static string Stringify<TSource>(this IEnumerable<TSource>? enumerable) where TSource : class
    {
        if (enumerable == null)
        {
            return string.Empty;
        }

        var items = enumerable.CollectNonNulls()
            .EnsureList()
            .Select(StringifyObject);

        return items.JoinString(", ");
    }

    /// <summary>
    /// Enumerate an IEnumerable source and getting the Index and the Item returned in a ValueTuple.
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>A Tuple list with Index for each element of your enumerable</returns>
    public static IEnumerable<(int Index, TSource Item)> EnumerateWithIndex<TSource>(
        this IEnumerable<TSource>? enumerable)
    {
        if (enumerable == null)
        {
            yield break;
        }

        var index = 0;
        foreach (var item in enumerable)
        {
            yield return (index++, item);
        }
    }

    /// <summary>
    /// Chainable method that joins the separator string with the items of your Enumerable.
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <param name="separator">String wanted to separate the elements</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <returns>A string concatenating each element with separator value</returns>
    public static string JoinString<TSource>(this IEnumerable<TSource>? enumerable, string separator = ",") =>
        enumerable == null
            ? string.Empty
            : string.Join(separator, enumerable.CollectNonNulls());

    /// <summary>
    /// Sorts the elements of a sequence in ascending order by using a specified <paramref name="comparer"/>.
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <param name="keySelector">A function to extract a key from an element</param>
    /// <param name="comparer">A function to compare keys</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector</typeparam>
    /// <returns>An <see cref="IEnumerable{TElement}"/> whose elements are sorted according to a key</returns>
    public static IEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource>? enumerable,
        Func<TSource, TKey> keySelector, Func<TKey, TKey, int> comparer)
    {
        return enumerable?.OrderBy(keySelector, new DelegateComparer<TKey>(comparer)) ?? Enumerable.Empty<TSource>();
    }

    /// <summary>
    /// Sorts the elements of a sequence in descending order by using a specified <paramref name="comparer"/>.
    /// </summary>
    /// <param name="enumerable">Your Enumerable</param>
    /// <param name="keySelector">A function to extract a key from an element</param>
    /// <param name="comparer">A function to compare keys</param>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector</typeparam>
    /// <returns>An <see cref="IEnumerable{TElement}"/> whose elements are sorted according to a key</returns>
    public static IEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource>? enumerable,
        Func<TSource, TKey> keySelector, Func<TKey, TKey, int> comparer)
    {
        return enumerable?.OrderByDescending(keySelector, new DelegateComparer<TKey>(comparer)) ??
               Enumerable.Empty<TSource>();
    }

    private static string StringifyObject(object obj)
    {
        var type = obj.GetType();
        var properties = type.GetProperties();

        var propertyStrings = new List<string>();

        foreach (var property in properties)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(obj);
            var value = "null";

            if (propertyValue != null)
            {
                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) &&
                    property.PropertyType != typeof(string))
                {
                    var collection = ((IEnumerable)propertyValue).Cast<object>();
                    var collectionStrings = collection.Select(StringifyObject)
                        .EnsureList();

                    value = $"[{collectionStrings.JoinString(", ")}]";
                }
                else
                {
                    value = propertyValue.ToString();
                }

                if (property.PropertyType == typeof(string))
                {
                    value = $"\"{value}\"";
                }
            }

            propertyStrings.Add($"\"{propertyName}\": {value}");
        }

        return $"{{ {propertyStrings.JoinString(", ")} }}";
    }

    private sealed class DelegateComparer<T>(Func<T, T, int> comparer) : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            return comparer(x, y);
        }
    }
}