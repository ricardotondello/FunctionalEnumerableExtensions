
# FunctionalEnumerableExtensions 🌟

`FunctionalEnumerableExtensions` is a C# class library that provides a set of extension methods for working with enumerable collections.
These extensions are designed to enhance memory efficiency and make common operations more convenient.
Whether you're converting to lists, arrays, or working with spans, these extensions aim to improve your code's performance and readability.

## Installation 🚀

To easily integrate the FunctionalEnumerableExtensions library into your project, you can use NuGet Package Manager.
NuGet is a package manager for .NET that simplifies the process of adding, removing,
and updating libraries in your applications.

After that import the `FunctionalEnumerableExtensions` namespace in your code files where you want to use the provided extension methods:

   ```csharp
   using FunctionalEnumerableExtensions;
   ```

## Available Extension Methods 🛠️

### `List<T> EnsureList<T>(this IEnumerable<T> enumerable)`

Prevent memory allocation when converting to a list using LINQ's `.ToList()`.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
List<int> myList = myEnumerable.EnsureList();
```

### `T[] EnsureArray<T>(this IEnumerable<T> enumerable)`

Prevent memory allocation when converting to an array using LINQ's `.ToArray()`.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
T[] myArray = myEnumerable.EnsureArray();
```

### `Span<T> AsSpan<T>(this IEnumerable<T> enumerable)`

**Warning: DO NOT use Span if you would change the list while looping into it, it can cause exceptions.**

Convert the enumerable collection to a Span, suitable for in-place data processing.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
Span<T> mySpan = myEnumerable.AsSpan();
```

### HashSet<T> EnsureHashSet<T>(this IEnumerable<T> enumerable)
Prevent memory allocation by casting an IEnumerable to a HashSet<T> if it's already of that type, otherwise create a new HashSet<T>.

Throws an ArgumentNullException if the input enumerable is null.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
HashSet<T> myHashSet = myEnumerable.EnsureHashSet();
```

### IEnumerable<T> CollectNonNulls<T>(this IEnumerable<T> enumerable)
Filter out non-null items from the input IEnumerable<T>.

Throws an ArgumentNullException if the input enumerable is null.
**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
var myFilteredList = myEnumerable.CollectNonNulls();
```