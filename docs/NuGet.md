
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

### `EnsureList`

Prevent memory allocation when converting to a list using LINQ's `.ToList()`.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
List<int> myList = myEnumerable.EnsureList();
```

### `EnsureArray`

Prevent memory allocation when converting to an array using LINQ's `.ToArray()`.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
T[] myArray = myEnumerable.EnsureArray();
```

### `AsSpan`

**Warning: DO NOT use Span if you would change the list while looping into it, it can cause exceptions.**

Convert the enumerable collection to a Span, suitable for in-place data processing.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
Span<T> mySpan = myEnumerable.AsSpan();
```

### `EnsureHashSet`
Prevent memory allocation by casting an IEnumerable to a HashSet<T> if it's already of that type, otherwise create a new HashSet<T>.

Throws an ArgumentNullException if the input enumerable is null.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
HashSet<T> myHashSet = myEnumerable.EnsureHashSet();
```

### `CollectNonNulls`
Filter out non-null items from the input IEnumerable<T>.

Throws an ArgumentNullException if the input enumerable is null.
**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
var myFilteredList = myEnumerable.CollectNonNulls();
```

### `EnsureEnumerable`
Prevent the enumerable to be null.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
var myNotNullEnumerable = myEnumerable.EnsureEnumerable();
```

### `SplitBy`
Splits the list according to the predicate.

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.
- `predicate` (Func<T, bool>): Condition to be applied to separate the enumerable

**Usage:**
```csharp
var (desiredItems, remainingItems) = enumerable.SplitBy(customer => customer.LoyaltyTimeInYears > 20);
```

### `IsNullOrEmpty`
Checks if the list is null or empty

**Parameters:**
- `enumerable` (IEnumerable<T>): The input enumerable collection.

**Usage:**
```csharp
var result = enumerable.IsNullOrEmpty();
```