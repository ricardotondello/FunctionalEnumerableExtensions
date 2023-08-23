namespace FunctionalEnumerableExtensionsTests;

public class FunctionalEnumerableExtensionsTests
{
    [Fact]
    public void EnsureList_WithNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureList();

        action.Should().Throw<ArgumentNullException>()
            .WithParameterName("enumerable")
            .WithMessage("is null (Parameter 'enumerable')");
    }

    [Fact]
    public void EnsureList_WithList_ReturnsSameList()
    {
        var input = new List<string> { "apple", "banana", "cherry" };

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
    public void EnsureList_WithNullEnumerable_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureList();

        action.Should().Throw<ArgumentNullException>()
            .WithMessage("is null (Parameter 'enumerable')")
            .And.ParamName.Should().Be("enumerable");
    }

    [Fact]
    public void EnsureArray_WithNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureArray();

        action.Should().Throw<ArgumentNullException>()
            .WithParameterName("enumerable")
            .WithMessage("is null (Parameter 'enumerable')");
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
    public void EnsureArray_WithNullEnumerable_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureArray();

        action.Should().Throw<ArgumentNullException>()
            .WithMessage("is null (Parameter 'enumerable')")
            .WithParameterName("enumerable");
    }

    [Fact]
    public void AsSpan_WithNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.AsSpan();

        action.Should().Throw<ArgumentNullException>()
            .WithParameterName("enumerable")
            .WithMessage("is null (Parameter 'enumerable')");
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
    public void AsSpan_WithNullEnumerable_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.AsSpan();

        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("enumerable");
        action.Should().Throw<ArgumentNullException>()
            .And.Message.Should().Be("is null (Parameter 'enumerable')");
    }
    
    [Fact]
    public void CollectNonNulls_WithNullInput_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<object> input = null!;

        // Act
        Action action = () => input.CollectNonNulls();

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .WithParameterName("enumerable")
            .WithMessage("is null (Parameter 'enumerable')");
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
        result.Should().BeEquivalentTo(new [] {1, 3, 5});
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
    public void EnsureHashSet_WithNullInput_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<object> input = null!;

        // Act
        Action action = () => input.EnsureHashSet();

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .WithParameterName("enumerable")
            .WithMessage("is null (Parameter 'enumerable')");
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
}