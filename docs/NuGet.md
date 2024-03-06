
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

**Usage:**
```csharp
List<int> myList = myEnumerable.EnsureList();
```

### `EnsureArray`

Prevent memory allocation when converting to an array using LINQ's `.ToArray()`.

**Usage:**
```csharp
T[] myArray = myEnumerable.EnsureArray();
```

### `AsSpan`

**Warning: DO NOT use Span if you would change the list while looping into it, it can cause exceptions.**

Convert the enumerable collection to a Span, suitable for in-place data processing.

**Usage:**
```csharp
Span<T> mySpan = myEnumerable.AsSpan();
```

### `EnsureHashSet`

Prevent memory allocation by casting an IEnumerable to a HashSet<T> if it's already of that type, otherwise create a new HashSet<T>.

**Usage:**
```csharp
HashSet<T> myHashSet = myEnumerable.EnsureHashSet();
```

### `CollectNonNulls`

Filter out non-null items from the input IEnumerable<T>.

**Usage:**
```csharp
var myFilteredList = myEnumerable.CollectNonNulls();
```

### `EnsureEnumerable`

Prevent the enumerable to be null.

**Usage:**
```csharp
var myNotNullEnumerable = myEnumerable.EnsureEnumerable();
```

### `SplitBy`

Splits the list according to the predicate.

**Usage:**
```csharp
var (desiredItems, remainingItems) = enumerable.SplitBy(customer => customer.LoyaltyTimeInYears > 20);
```

### `IsNullOrEmpty`

Checks if the list is null or empty

**Usage:**
```csharp
var result = enumerable.IsNullOrEmpty();
```

### `WhereIf`

Introduces optional filtering, applying a predicate only if a specified condition holds true.

**Usage:**
```csharp
var result = enumerable.WhereIf(YourBooleanCondition(), w => w > 0);
```

### `Stringify`

Converts a collection of non-null objects to a string by concatenating their properties recursively, separated by commas.

**Usage:**
```csharp
var result = enumerable.Stringify();
```

### `EnumerateWithIndex`

Enumerate an IEnumerable source and getting the Index and the Item returned in a ValueTuple.

**Usage**
```csharp
var result = enumerable.EnumerateWithIndex();
```

### `JoinString`

Chainable method that joins the separator string with the items of your Enumerable.

**Usage**
```csharp
var result = list.Select(s => s.Name).JoinString();
```
