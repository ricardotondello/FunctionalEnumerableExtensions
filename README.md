
# FunctionalEnumerableExtensions 🌟

[![Build](https://github.com/ricardotondello/FunctionalEnumerableExtensions/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/ricardotondello/FunctionalEnumerableExtensions/actions/workflows/dotnet.yml)
[![Code Coverage](https://img.shields.io/badge/Code%20Coverage-100%25-success?style=flat)](https://ricardotondello.github.io/FunctionalEnumerableExtensions/unittests)
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

## Contributing 👥

Contributions are welcome! If you find a bug or have a feature request, please open an issue on GitHub.
If you would like to contribute code, please fork the repository and submit a pull request.

## License 📄

This project is licensed under the MIT License.
See [LICENSE](https://github.com/ricardotondello/FunctionalEnumerableExtensions/blob/main/LICENSE) for more information.

## Support ☕

<a href="https://www.buymeacoffee.com/ricardotondello" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" style="height: 60px !important;width: 217px !important;" ></a>