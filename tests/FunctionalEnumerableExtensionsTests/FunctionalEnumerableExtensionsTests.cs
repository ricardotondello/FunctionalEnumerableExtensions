namespace FunctionalEnumerableExtensionsTests;

public class FunctionalEnumerableExtensionsTests
{
    [Fact]
    public void EnsureList_WithNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureList();

        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("xs");
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

        var result = input.EnsureList();

        result.Should().NotBeSameAs(input).And.BeEquivalentTo(input);
    }

    [Fact]
    public void EnsureList_WithNullEnumerable_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureList();

        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("xs");
    }

    [Fact]
    public void EnsureArray_WithNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.EnsureArray();

        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("xs");
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

        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("xs");
    }

    [Fact]
    public void AsSpan_WithNull_ThrowsArgumentNullException()
    {
        IEnumerable<int> input = null!;

        Action action = () => input.AsSpan();

        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("xs");
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

        action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("xs");
    }
}