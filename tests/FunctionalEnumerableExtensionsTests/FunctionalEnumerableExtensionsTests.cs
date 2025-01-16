namespace FunctionalEnumerableExtensionsTests;

public class FunctionalEnumerableExtensionsTests
{
    [Fact]
    public void EnsureList_WithNull_ShouldNotThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        var ex = Record.Exception(() => input.EnsureList());
        Assert.Null(ex);
    }

    [Fact]
    public void EnsureList_WithList_ReturnsSameList()
    {
        var input = new List<string> { "apple", "banana", "cherry" };

        var result = input.EnsureList();

        Assert.Equal(input, result);
    }

    [Fact]
    public void EnsureList_WithEmptyList_ReturnsEmptyList()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var input = new List<string>();

        var result = input.EnsureList();

        Assert.Equal(input, result);
    }

    [Fact]
    public void EnsureList_WithEnumerable_ReturnsNewList()
    {
        var input = Enumerable.Range(1, 5);

        // ReSharper disable PossibleMultipleEnumeration
        var result = input.EnsureList();

        Assert.NotSame(input, result);
        Assert.Equivalent(input, result);
    }

    [Fact]
    public void EnsureList_WithNullEnumerable_ShouldReturnEmptyList()
    {
        IEnumerable<int> input = null!;

        var result = input.EnsureList();

        Assert.Empty(result);
    }

    [Fact]
    public void EnsureArray_WithNull_ShouldNotThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        var ex = Record.Exception(() => input.EnsureArray());
        Assert.Null(ex);
    }

    [Fact]
    public void EnsureArray_WithArray_ReturnsSameArray()
    {
        var input = new[] { 1, 2, 3 };

        var result = input.EnsureArray();

        Assert.Same(result, input);
    }

    [Fact]
    public void EnsureArray_WithEnumerable_ReturnsNewArray()
    {
        IEnumerable<string> input = new List<string> { "apple", "banana", "cherry" };

        var result = input.EnsureArray();

        Assert.NotSame(input, result);
        Assert.Equivalent(input, result);
    }

    [Fact]
    public void EnsureArray_WithNullEnumerable_ShouldBeEmpty()
    {
        IEnumerable<int> input = null!;

        var result = input.EnsureArray();

        Assert.Empty(result);
    }

    [Fact]
    public void AsSpan_WithNull_ShouldNotThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        var ex = Record.Exception(() => input.AsSpan());
        Assert.Null(ex);
    }

    [Fact]
    public void AsSpan_WithArray_ReturnsSpanOfArray()
    {
        var input = new[] { 1, 2, 3 };

        var result = input.AsSpan();

        Assert.Equivalent(result.ToArray(), input);
    }

    [Fact]
    public void AsSpan_WithEnumerable_ReturnsSpanOfEnumerable()
    {
        IEnumerable<string> input = new List<string> { "apple", "banana", "cherry" };

        var result = input.AsSpan();

        Assert.Equivalent(result.ToArray(), input);
    }

    [Fact]
    public void AsSpan_WithNullEnumerable_ShouldNotThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        var ex = Record.Exception(() => input.AsSpan());
        Assert.Null(ex);
    }

    [Fact]
    public void CollectNonNulls_WithNullInput_ShouldNotThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<object> input = null!;

        // Act
        var ex = Record.Exception(() => input.CollectNonNulls());

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void CollectNonNulls_WithAllNonNullItems_ReturnsSameItems()
    {
        // Arrange
        IEnumerable<string> input = new List<string> { "a", "b", "c" };

        // Act
        var result = input.CollectNonNulls();

        // Assert
        Assert.Equivalent(new List<string> { "a", "b", "c" }, result);
    }

    [Fact]
    public void CollectNonNulls_WithSomeNullItems_ReturnsNonNullItemsOnly()
    {
        // Arrange
        IEnumerable<int?> input = new List<int?>
        {
            1,
            null,
            3,
            null,
            5
        };

        // Act
        var result = input.CollectNonNulls();
        var expectedValue = new List<int> { 1, 3, 5 };

        // Assert
        Assert.Equivalent(expectedValue, result);
    }

    [Fact]
    public void CollectNonNulls_WithAllNullItems_ReturnsEmptyCollection()
    {
        // Arrange
        IEnumerable<object> input = new List<object> { null!, null!, null! };

        // Act
        var result = input.CollectNonNulls();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void EnsureHashSet_WithNullInput_ShouldNotThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<object> input = null!;

        // Act
        var ex = Record.Exception(() => input.EnsureHashSet());

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void EnsureHashSet_WithHashSetInput_ReturnsSameHashSet()
    {
        // Arrange
        var input = new HashSet<int> { 1, 2, 3 };

        // Act
        var result = input.EnsureHashSet();

        // Assert
        Assert.Same(input, result);
    }

    [Fact]
    public void EnsureHashSet_WithListInput_ReturnsNewHashSetWithSameItems()
    {
        // Arrange
        var input = new List<string> { "a", "b", "c" };

        // Act
        var result = input.EnsureHashSet();

        // Assert
        Assert.Equivalent(new List<string> { "a", "b", "c" }, result);
        Assert.NotSame(input, result);
    }

    [Fact]
    public void EnsureHashSet_WithEmptyInput_ReturnsEmptyHashSet()
    {
        // Arrange
        // ReSharper disable once CollectionNeverUpdated.Local
        var input = new List<int>();

        // Act
        var result = input.EnsureHashSet();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void EnsureEnumerable_Null_ReturnsEmptyEnumerable()
    {
        // Arrange
        IEnumerable<string> input = null!;

        // Act
        var result = input.EnsureEnumerable();

        // Assert
        // ReSharper disable once UseCollectionExpression
        Assert.Same(Enumerable.Empty<string>(), result);
    }

    [Fact]
    public void EnsureEnumerable_NotNull_ReturnsEnumerableItSelf()
    {
        // Arrange
        // ReSharper disable once UseCollectionExpression
        IEnumerable<string> input = new[] { "a", "b" };

        // Act
        var result = input.EnsureEnumerable();

        // Assert
        Assert.Same(input, result);
    }

    [Fact]
    public void SplitBy_WhenPredicateMatch_ReturnsBothLists()
    {
        // Arrange
        var input = new[] { "a", "b", "b", "c" };

        // Act
        var result = input.SplitBy(s => s.Equals("b", StringComparison.InvariantCultureIgnoreCase));

        // Assert
        var expectedDesiredItems = new[] { "b", "b" };
        var expectedRemainingItems = new[] { "a", "c" };
        Assert.Equal(expectedDesiredItems, result.DesiredItems);
        Assert.Equal(expectedRemainingItems, result.RemainingItems);
    }

    [Fact]
    public void SplitBy_WhenPredicateDoesntMatch_ReturnsBothListsWithDesiredEmpty()
    {
        // Arrange
        var input = new[] { "a", "b", "b", "c" };

        // Act
        var (desiredItems, remainingItems) =
            input.SplitBy(s => s.Equals("d", StringComparison.InvariantCultureIgnoreCase));

        // Assert
        var expectedRemaining = new[] { "a", "b", "b", "c" };
        Assert.Empty(desiredItems);
        Assert.Equal(expectedRemaining, remainingItems);
    }

    [Fact]
    public void SplitBy_WhenPredicateMatchesAll_ReturnsBothListsWithRemainingEmpty()
    {
        // Arrange
        var input = new[] { "a", "a", "a", "a" };

        // Act
        var result = input.SplitBy(s => s.Equals("a", StringComparison.InvariantCultureIgnoreCase));

        // Assert
        var expectedDesiredItems = new[] { "a", "a", "a", "a" };
        Assert.Equal(expectedDesiredItems, result.DesiredItems);
        Assert.Empty(result.RemainingItems);
    }

    [Fact]
    public void SplitBy_WhenEnumerableIsNull_ShouldNotTThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<string> input = null!;

        // Act
        var ex = Record.Exception(() =>
            input.SplitBy(s => s.Equals("whatever", StringComparison.InvariantCultureIgnoreCase)));

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void IsNullOrEmpty_WhenEnumerableIsNull_ShouldReturnTrue()
    {
        // Arrange
        IEnumerable<string> input = null!;

        // Act
        var result = input.IsNullOrEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_WhenEnumerableIsEmpty_ShouldReturnTrue()
    {
        // Arrange
        var input = Enumerable.Empty<string>();

        // Act
        var result = input.IsNullOrEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_WhenEnumerableIsNotNull_ShouldReturnFalse()
    {
        // Arrange
        var input = new[] { "a", "b" };

        // Act
        var result = input.IsNullOrEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void WhereIf_WhenConditionIsTrue_ShouldApplyWhereToTheEnumerable()
    {
        //Arrange
        var list = new[] { 1, 2, 3 };

        //Act

        var result = list.WhereIf(true, w => w > 2);

        //Assert
        var expectedResult = new[] { 3 };
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void WhereIf_WhenConditionIsFalse_ShouldAReturnTheEnumerableItSelf()
    {
        //Arrange
        var list = new[] { 1, 2, 3 };

        //Act
        var result = list.WhereIf(false, w => w > 2);

        //Assert
        Assert.Equal(list, result);
    }

    [Fact]
    public void WhereIf_WithNullEnumerable_ShouldNotTThrowsArgumentNullException()
    {
        //Arrange
        IEnumerable<int> input = null!;

        //Act
        var ex = Record.Exception(() => input.WhereIf(true, w => w > 0));

        //Assert
        Assert.Null(ex);
    }

    [Fact]
    public void Each_WithNullEnumerable_ShouldNotTThrowsArgumentNullException()
    {
        //Arrange
        IEnumerable<int> input = null!;

        //Act
        var ex = Record.Exception(() => input.Each(a => { _ = a.ToString(); }));

        //Assert
        Assert.Null(ex);
    }

    [Fact]
    public void Each_ShouldExecuteTheActionForItems()
    {
        //Arrange
        var list = new[] { 1, 2, 3 };
        var doubleList = new List<int>();

        //Act
        list.Each(item => { doubleList.Add(item * 2); });

        //Assert
        var expectedValue = new[] { 2, 4, 6 };
        Assert.Equal(expectedValue, doubleList);
    }

    [Fact]
    public void Stringify_ShouldReturnAStringWithTheElements()
    {
        //Arrange
        var dob = new DateTime(2024, 01, 28, 15, 44, 20, DateTimeKind.Utc);
        var list = Enumerable.Range(0, 2)
            .Select(s => new MyClass(Name: $"My Name is {s}", Age: s, Dob: dob, Classes: Enumerable.Range(1, 3)
                .Select(s1 => new MyClass(Name: $"child {s1}", Age: s1, Dob: null, Classes: null))))
            .ToList();

        list.Add(null!);

        //Act
        var result = list.Stringify();

        //Assert
        var stringDob = $"{dob}";
        var expected = "{ \"Name\": \"My Name is 0\", \"Age\": 0, \"Dob\": " + stringDob + ", " +
                       "\"Classes\": [{ \"Name\": \"child 1\", \"Age\": 1, \"Dob\": null, \"Classes\": null }, " +
                       "{ \"Name\": \"child 2\", \"Age\": 2, \"Dob\": null, \"Classes\": null }, " +
                       "{ \"Name\": \"child 3\", \"Age\": 3, \"Dob\": null, \"Classes\": null }] }, " +
                       "{ \"Name\": \"My Name is 1\", \"Age\": 1, \"Dob\": " + stringDob + ", " +
                       "\"Classes\": [{ \"Name\": \"child 1\", \"Age\": 1, \"Dob\": null, \"Classes\": null }, " +
                       "{ \"Name\": \"child 2\", \"Age\": 2, \"Dob\": null, \"Classes\": null }, " +
                       "{ \"Name\": \"child 3\", \"Age\": 3, \"Dob\": null, \"Classes\": null }] }";

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Stringify_WithNullEnumerable_ShouldReturnEmpty()
    {
        //Arrange
        IEnumerable<MyClass> input = null!;

        //Act
        var result = input.Stringify();

        //Assert
        Assert.Empty(result);
    }

    [Fact]
    public void EnumerateWithIndex_WithValidEnumerable_ShouldEnumerateWithIndexes()
    {
        //Arrange
        var list = new List<MyClass>
        {
            new("Name1", 21, DateTime.UtcNow, null),
            new("Name2", 21, DateTime.UtcNow, null),
            new("Name3", 21, DateTime.UtcNow, null),
            new("Name4", 21, DateTime.UtcNow, null)
        };

        //Act
        var listWithIndex = list.EnumerateWithIndex();

        //Assert
        var indexCheck = 0;
        foreach (var (index, item) in listWithIndex)
        {
            Assert.Equal(indexCheck++, index);
            Assert.NotNull(item);
        }
    }

    [Fact]
    public void EnumerateWithIndex_WithInvalidEnumerable_ShouldYieldBreak()
    {
        //Arrange
        IEnumerable<MyClass> list = null!;

        //Act
        var listWithIndex = list.EnumerateWithIndex();

        //Assert
        Assert.Empty(listWithIndex);
    }

    [Fact]
    public void JoinString_WithValidEnumerable_ShouldReturnJoinedValue()
    {
        //Arrange
        var list = new List<MyClass>
        {
            new("Name1", 21, new DateTime(2024, 01, 01, 10, 50, 56, DateTimeKind.Utc), null),
            new("Name2", 22, new DateTime(2023, 01, 01, 10, 50, 56, DateTimeKind.Utc), null),
            new("Name3", 23, new DateTime(2022, 01, 01, 10, 50, 56, DateTimeKind.Utc), null),
            new("Name4", 24, new DateTime(2021, 01, 01, 10, 50, 56, DateTimeKind.Utc), null)
        };

        //Act
        var resultName = list.Select(s => s.Name)
            .JoinString();
        var resultAge = list.Select(s => s.Age)
            .JoinString();
        var resultDate = list.Select(s => s.Dob!.Value.Year)
            .JoinString();
        var resultClass = list.Select(s => s.Classes)
            .JoinString();

        //Assert
        Assert.Equal("Name1,Name2,Name3,Name4", resultName);
        Assert.Equal("21,22,23,24", resultAge);
        Assert.Equal("2024,2023,2022,2021", resultDate);
        Assert.Equal(string.Empty, resultClass);
    }

    [Fact]
    public void JoinString_WithInvalidEnumerable_ShouldReturnEmptyString()
    {
        //Arrange
        List<string> list = null!;

        //Act
        var result = list.JoinString();

        //Assert
        Assert.Empty(result);
    }

    [Fact]
    public void OrderBy_NullEnumerable_ReturnsEmpty()
    {
        //Arrange
        List<int> list = null!;

        //Act
        var result = list.OrderBy(x => x, (a, b) => a.CompareTo(b));

        //Assert
        Assert.Empty(result);
    }

    [Fact]
    public void OrderBy_EmptyEnumerable_ReturnsEmpty()
    {
        //Arrange
        var list = Enumerable.Empty<int>();

        //Act
        var result = list.OrderBy(x => x, (a, b) => a.CompareTo(b));

        //Assert
        Assert.Empty(result);
    }

    [Fact]
    public void OrderBy_SingleElement_ReturnsSameElement()
    {
        //Arrange
        IEnumerable<int> list = new List<int> { 5 };

        //Act
        var result = list.OrderBy(x => x, (a, b) => a.CompareTo(b))
            .ToList();

        //Assert
        Assert.Single(result);
        Assert.Equal(5, result[0]);
    }

    [Fact]
    public void OrderBy_ComplexOrder_SortsCorrectly()
    {
        //Arrange
        IEnumerable<MyFakeRecord> list = new List<MyFakeRecord>
        {
            new("ZZZ", 5),
            new("WWW", 1),
            new("ZZZ", 2),
            new("CCC", 6),
            new("AAA", 9),
            new("ZZZ", 4),
            new("BBB", 10),
            new("ZZZ", 1),
            new("ZZZ", 3)
        };

        //Act
        var result = list.OrderBy(x => (x.Name, x.Age), (a, b) =>
            {
                var nameComparison = string.Compare(a.Name, b.Name, StringComparison.Ordinal);
                return nameComparison != 0
                    ? nameComparison
                    : a.Age.CompareTo(b.Age);
            })
            .ToList();

        //Assert
        var expected = new List<MyFakeRecord>
        {
            new("AAA", 9),
            new("BBB", 10),
            new("CCC", 6),
            new("WWW", 1),
            new("ZZZ", 1),
            new("ZZZ", 2),
            new("ZZZ", 3),
            new("ZZZ", 4),
            new("ZZZ", 5)
        };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void OrderByDescending_NullEnumerable_ReturnsEmpty()
    {
        //Arrange
        IEnumerable<int>? list = null;

        //Act
        var result = list.OrderByDescending(x => x, (a, b) => a.CompareTo(b));

        //Assert
        Assert.Empty(result);
    }

    [Fact]
    public void OrderByDescending_EmptyEnumerable_ReturnsEmpty()
    {
        //Arrange
        var list = Enumerable.Empty<int>();

        //Act
        var result = list.OrderByDescending(x => x, (a, b) => a.CompareTo(b));

        //Assert
        Assert.Empty(result);
    }

    [Fact]
    public void OrderByDescending_SingleElement_ReturnsSameElement()
    {
        //Arrange
        IEnumerable<int> list = new List<int> { 5 };

        //Act
        var result = list.OrderByDescending(x => x, (a, b) => a.CompareTo(b))
            .ToList();

        //Assert
        Assert.Single(result);
        Assert.Equal(5, result[0]);
    }

    [Fact]
    public void OrderByDescending_ComplexOrder_SortsCorrectly()
    {
        //Arrange
        IEnumerable<MyFakeRecord> list = new List<MyFakeRecord>
        {
            new("ZZZ", 5),
            new("WWW", 1),
            new("ZZZ", 2),
            new("CCC", 6),
            new("AAA", 9),
            new("ZZZ", 4),
            new("BBB", 10),
            new("ZZZ", 1),
            new("ZZZ", 3)
        };

        //Act
        var result = list.OrderByDescending(x => (x.Name, x.Age), (a, b) =>
            {
                var nameComparison = string.Compare(a.Name, b.Name, StringComparison.Ordinal);
                return nameComparison != 0
                    ? nameComparison
                    : a.Age.CompareTo(b.Age);
            })
            .ToList();

        //Assert
        var expected = new List<MyFakeRecord>
        {
            new("ZZZ", 5),
            new("ZZZ", 4),
            new("ZZZ", 3),
            new("ZZZ", 2),
            new("ZZZ", 1),
            new("WWW", 1),
            new("CCC", 6),
            new("BBB", 10),
            new("AAA", 9)
        };

        Assert.Equal(expected, result);
    }
}

internal record MyClass(string? Name, int Age, DateTime? Dob, IEnumerable<MyClass>? Classes);

internal record MyFakeRecord(string Name, int Age);