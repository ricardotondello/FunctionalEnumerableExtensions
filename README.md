
# FunctionalEnumerableExtensions 🌟

[![Build](https://github.com/ricardotondello/FunctionalEnumerableExtensions/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/ricardotondello/FunctionalEnumerableExtensions/actions/workflows/dotnet.yml)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=ricardotondello_FunctionalEnumerableExtensions&metric=alert_status)](https://sonarcloud.io/dashboard?id=ricardotondello_FunctionalEnumerableExtensions)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ricardotondello_FunctionalEnumerableExtensions&metric=coverage)](https://sonarcloud.io/component_measures?id=ricardotondello_FunctionalEnumerableExtensions&metric=coverage)
[![NuGet latest version](https://badgen.net/nuget/v/FunctionalEnumerableExtensions/latest)](https://nuget.org/packages/FunctionalEnumerableExtensions)
[![NuGet downloads](https://img.shields.io/nuget/dt/FunctionalEnumerableExtensions)](https://www.nuget.org/packages/FunctionalEnumerableExtensions)

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

Chainable extensions that joins the separator string with the elements of your Enumerable.

**Usage**
```csharp
var result = list.Select(s => s.Name).JoinString();
```

### `OrderBy` and `OrderByDescending` with a delegate comparer

Sorts the elements of a sequence in ascending/descending order by using a specified comparer.

**Usage**
```csharp
record Customer(string Name, int Age);

//Order by name then by age
//user OrderByDescending to order descendingly
var result = values.OrderBy(x => (x.Name, x.Age), (a, b) =>
        {
            var nameComparison = string.Compare(a.Name, b.Name, StringComparison.Ordinal);
            return nameComparison != 0 ? nameComparison : a.Age.CompareTo(b.Age);
        });
```

## Contributing 👥

Contributions are welcome! If you find a bug or have a feature request, please open an issue on GitHub.
If you would like to contribute code, please fork the repository and submit a pull request.

## License 📄

This project is licensed under the MIT License.
See [LICENSE](https://github.com/ricardotondello/FunctionalEnumerableExtensions/blob/main/LICENSE) for more information.

## Support ☕

<a href="https://www.buymeacoffee.com/ricardotondello" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" style="height: 60px !important;width: 217px !important;" ></a>