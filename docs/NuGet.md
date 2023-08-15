
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

### `List<T> EnsureList<T>(this IEnumerable<T> xs)`

Prevent memory allocation when converting to a list using LINQ's `.ToList()`.

**Parameters:**
- `xs` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
List<int> myList = myEnumerable.EnsureList();
```

### `T[] EnsureArray<T>(this IEnumerable<T> xs)`

Prevent memory allocation when converting to an array using LINQ's `.ToArray()`.

**Parameters:**
- `xs` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
T[] myArray = myEnumerable.EnsureArray();
```

### `Span<T> AsSpan<T>(this IEnumerable<T> xs)`

**Warning: DO NOT use Span if you would change the list while looping into it, it can cause exceptions.**

Convert the enumerable collection to a Span, suitable for in-place data processing.

**Parameters:**
- `xs` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
Span<T> mySpan = myEnumerable.AsSpan();
```