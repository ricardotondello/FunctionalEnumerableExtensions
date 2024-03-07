using Xunit.Abstractions;

namespace FunctionalEnumerableExtensionsTests;

public class FunctionalEnumerableExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public FunctionalEnumerableExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void EnsureList_WithNull_ShouldNotThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureList();

        action.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void EnsureList_WithList_ReturnsSameList()
    {
        var input = new List<string> { "apple", "banana", "cherry" };

        var result = input.EnsureList();

        result.Should().BeSameAs(input);
    }

    [Fact]
    public void EnsureList_WithEmptyList_ReturnsEmptyList()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        var input = new List<string>();

        var result = input.EnsureList();

        result.Should().BeSameAs(input);
    }

    [Fact]
    public void EnsureList_WithEnumerable_ReturnsNewList()
    {
        var input = Enumerable.Range(1, 5);

        // ReSharper disable PossibleMultipleEnumeration
        var result = input.EnsureList();

        result.Should().NotBeSameAs(input).And.BeEquivalentTo(input);
    }

    [Fact]
    public void EnsureList_WithNullEnumerable_ShouldReturnEmptyList()
    {
        IEnumerable<int> input = null!;

        var result= input.EnsureList();

        result.Should().BeEmpty();
    }

    [Fact]
    public void EnsureArray_WithNull_ShouldNotThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureArray();

        action.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void EnsureArray_WithArray_ReturnsSameArray()
    {
        var input = new[] { 1, 2, 3 };

        var result = input.EnsureArray();

        result.Should().BeSameAs(input);
    }

    [Fact]
    public void EnsureArray_WithEnumerable_ReturnsNewArray()
    {
        IEnumerable<string> input = new List<string> { "apple", "banana", "cherry" };

        var result = input.EnsureArray();

        result.Should().NotBeSameAs(input).And.BeEquivalentTo(input);
    }

    [Fact]
    public void EnsureArray_WithNullEnumerable_ShouldBeEmpty()
    {
        IEnumerable<int> input = null!;

        var result = input.EnsureArray();

        result.Should().BeEmpty();
    }

    [Fact]
    public void AsSpan_WithNull_ShouldNotThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.AsSpan();

        action.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void AsSpan_WithArray_ReturnsSpanOfArray()
    {
        var input = new[] { 1, 2, 3 };

        var result = input.AsSpan();

        result.ToArray().Should().BeEquivalentTo(input);
    }

    [Fact]
    public void AsSpan_WithEnumerable_ReturnsSpanOfEnumerable()
    {
        IEnumerable<string> input = new List<string> { "apple", "banana", "cherry" };

        var result = input.AsSpan();

        result.ToArray().Should().BeEquivalentTo(input);
    }

    [Fact]
    public void AsSpan_WithNullEnumerable_ShouldNotThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.AsSpan();

        action.Should().NotThrow<ArgumentNullException>();
        action.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void CollectNonNulls_WithNullInput_ShouldNotThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<object> input = null!;

        // Act
        Action action = () => input.CollectNonNulls();

        // Assert
        action.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void CollectNonNulls_WithAllNonNullItems_ReturnsSameItems()
    {
        // Arrange
        IEnumerable<string> input = new List<string> { "a", "b", "c" };

        // Act
        var result = input.CollectNonNulls();

        // Assert
        result.Should().BeEquivalentTo("a", "b", "c");
    }

    [Fact]
    public void CollectNonNulls_WithSomeNullItems_ReturnsNonNullItemsOnly()
    {
        // Arrange
        IEnumerable<int?> input = new List<int?> { 1, null, 3, null, 5 };

        // Act
        var result = input.CollectNonNulls();

        // Assert
        result.Should().BeEquivalentTo(new[] { 1, 3, 5 });
    }

    [Fact]
    public void CollectNonNulls_WithAllNullItems_ReturnsEmptyCollection()
    {
        // Arrange
        IEnumerable<object> input = new List<object> { null!, null!, null! };

        // Act
        var result = input.CollectNonNulls();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void EnsureHashSet_WithNullInput_ShouldNotThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<object> input = null!;

        // Act
        Action action = () => input.EnsureHashSet();

        // Assert
        action.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void EnsureHashSet_WithHashSetInput_ReturnsSameHashSet()
    {
        // Arrange
        var input = new HashSet<int> { 1, 2, 3 };

        // Act
        var result = input.EnsureHashSet();

        // Assert
        result.Should().BeSameAs(input);
    }

    [Fact]
    public void EnsureHashSet_WithListInput_ReturnsNewHashSetWithSameItems()
    {
        // Arrange
        var input = new List<string> { "a", "b", "c" };

        // Act
        var result = input.EnsureHashSet();

        // Assert
        result.Should().BeEquivalentTo("a", "b", "c");
        result.Should().NotBeSameAs(input);
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
        result.Should().BeEmpty();
    }

    [Fact]
    public void EnsureEnumerable_Null_ReturnsEmptyEnumerable()
    {
        // Arrange
        IEnumerable<string> input = null!;

        // Act
        var result = input.EnsureEnumerable();

        // Assert
        result.Should().BeSameAs(Enumerable.Empty<string>());
    }

    [Fact]
    public void EnsureEnumerable_NotNull_ReturnsEnumerableItSelf()
    {
        // Arrange
        IEnumerable<string> input = new[] { "a", "b" };

        // Act
        var result = input.EnsureEnumerable();

        // Assert
        result.Should().BeSameAs(input);
    }

    [Fact]
    public void SplitBy_WhenPredicateMatch_ReturnsBothLists()
    {
        // Arrange
        var input = new[] { "a", "b", "b", "c" };

        // Act
        var result = input.SplitBy(s => s.Equals("b", StringComparison.InvariantCultureIgnoreCase));

        // Assert
        result.DesiredItems.Should().Contain(new[] { "b", "b" });
        result.RemainingItems.Should().Contain(new[] { "a", "c" });
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
        desiredItems.Should().BeEmpty();
        remainingItems.Should().Contain(new[] { "a", "b", "b", "c" });
    }

    [Fact]
    public void SplitBy_WhenPredicateMatchesAll_ReturnsBothListsWithRemainingEmpty()
    {
        // Arrange
        var input = new[] { "a", "a", "a", "a" };

        // Act
        var result = input.SplitBy(s => s.Equals("a", StringComparison.InvariantCultureIgnoreCase));

        // Assert
        result.DesiredItems.Should().Contain(new[] { "a", "a", "a", "a" });
        result.RemainingItems.Should().BeEmpty();
    }

    [Fact]
    public void SplitBy_WhenEnumerableIsNull_ShouldNotTThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<string> input = null!;

        // Act
        Action action = () => input.SplitBy(s => s.Equals("whatever", StringComparison.InvariantCultureIgnoreCase));

        // Assert
        action.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void IsNullOrEmpty_WhenEnumerableIsNull_ShouldReturnTrue()
    {
        // Arrange
        IEnumerable<string> input = null!;

        // Act
        var result = input.IsNullOrEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_WhenEnumerableIsEmpty_ShouldReturnTrue()
    {
        // Arrange
        var input = Enumerable.Empty<string>();

        // Act
        var result = input.IsNullOrEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_WhenEnumerableIsNotNull_ShouldReturnFalse()
    {
        // Arrange
        var input = new[] { "a", "b" };

        // Act
        var result = input.IsNullOrEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void WhereIf_WhenConditionIsTrue_ShouldApplyWhereToTheEnumerable()
    {
        //Arrange
        var list = new[] { 1, 2, 3 };

        //Act

        var result = list.WhereIf(true, w => w > 2);

        //Assert
        result.Should().Contain(new[] { 3 });
    }

    [Fact]
    public void WhereIf_WhenConditionIsFalse_ShouldAReturnTheEnumerableItSelf()
    {
        //Arrange
        var list = new[] { 1, 2, 3 };

        //Act
        var result = list.WhereIf(false, w => w > 2);

        //Assert
        result.Should().Contain(new[] { 1, 2, 3 });
    }

    [Fact]
    public void WhereIf_WithNullEnumerable_ShouldNotTThrowsArgumentNullException()
    {
        //Arrange
        IEnumerable<int> input = null!;

        //Act
        Action action = () => input.WhereIf(true, w => w > 0);

        //Assert
        action.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void Each_WithNullEnumerable_ShouldNotTThrowsArgumentNullException()
    {
        //Arrange
        IEnumerable<int> input = null!;

        //Act
        Action action = () => input.Each(a => { _ = a.ToString(); });

        //Assert
        action.Should().NotThrow<ArgumentNullException>();
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
        doubleList.Should().Contain(new[] { 2, 4, 6 });
    }

    [Fact]
    public void Stringify_ShouldReturnAStringWithTheElements()
    {
        //Arrange
        var dob = new DateTime(2024, 01, 28, 15, 44, 20, DateTimeKind.Utc);
        var list = Enumerable.Range(0, 2).Select(s => new MyClass(
            Name: $"My Name is {s}",
            Age: s,
            Dob: dob,
            Classes: Enumerable.Range(1, 3)
                .Select(s1 => new MyClass(Name: $"child {s1}", Age: s1, Dob: null, Classes: null))
        )).ToList();

        list.Add(null!);

        //Act
        var result = list.Stringify();

        //Assert
        _testOutputHelper.WriteLine($"result was :{result}");
        var stringDob = $"{dob}";
        result.Should()
            .Be(
                "{ \"Name\": \"My Name is 0\", \"Age\": 0, \"Dob\": "+stringDob+", " +
                "\"Classes\": [{ \"Name\": \"child 1\", \"Age\": 1, \"Dob\": null, \"Classes\": null }, " +
                "{ \"Name\": \"child 2\", \"Age\": 2, \"Dob\": null, \"Classes\": null }, " +
                "{ \"Name\": \"child 3\", \"Age\": 3, \"Dob\": null, \"Classes\": null }] }, " +
                "{ \"Name\": \"My Name is 1\", \"Age\": 1, \"Dob\": "+stringDob+", " +
                "\"Classes\": [{ \"Name\": \"child 1\", \"Age\": 1, \"Dob\": null, \"Classes\": null }, " +
                "{ \"Name\": \"child 2\", \"Age\": 2, \"Dob\": null, \"Classes\": null }, " +
                "{ \"Name\": \"child 3\", \"Age\": 3, \"Dob\": null, \"Classes\": null }] }");
    }

    [Fact]
    public void Stringify_WithNullEnumerable_ShouldReturnEmpty()
    {
        //Arrange
        IEnumerable<MyClass> input = null!;

        //Act
        var result = input.Stringify();

        //Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void EnumerateWithIndex_WithValidEnumerable_ShouldEnumerateWithIndexes()
    {
        //Arrange
        var list = new List<MyClass>
        {
            new ("Name1", 21, DateTime.UtcNow, null),
            new ("Name2", 21, DateTime.UtcNow, null),
            new ("Name3", 21, DateTime.UtcNow, null),
            new ("Name4", 21, DateTime.UtcNow, null)
        };
        
        //Act
        var listWithIndex = list.EnumerateWithIndex();
        
        //Assert
        var indexCheck = 0;
        foreach (var (index, item) in listWithIndex)
        {
            index.Should().Be(indexCheck++);
            item.Should().NotBeNull();
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
        listWithIndex.Should().BeEmpty();
    }
    
    [Fact]
    public void JoinString_WithValidEnumerable_ShouldReturnJoinedValue()
    {
        //Arrange
        var list = new List<MyClass>
        {
            new ("Name1", 21, DateTime.UtcNow, null),
            new ("Name2", 21, DateTime.UtcNow, null),
            new ("Name3", 21, DateTime.UtcNow, null),
            new ("Name4", 21, DateTime.UtcNow, null)
        };
        
        //Act
        var result = list.Select(s => s.Name).JoinString();
        
        //Assert
        result.Should().Be("Name1,Name2,Name3,Name4");
    }
    
    [Fact]
    public void JoinString_WithInvalidEnumerable_ShouldReturnEmptyString()
    {
        //Arrange
        List<string> list = null!;
        
        //Act
        var result = list.JoinString();
        
        //Assert
        result.Should().BeEmpty();
    }
}

internal record MyClass(string? Name, int Age, DateTime? Dob, IEnumerable<MyClass>? Classes);