using codingtest;
using codingtest.Interfaces;
using FluentAssertions;

namespace tests;

public class AnagramFinderTests
{
    private IAnagramFinder _anagramFinder;

    [SetUp]
    public void Setup()
    {
        _anagramFinder = new AnagramFinder();
    }

    [Test]
    public void ShouldReturnExpectedAnagrams()
    {
        // Arrange
        string[] inputWords = { "abc", "bac", "fun", "unf", "cba", "hello" };

        // Act
        var groupedAnagrams = _anagramFinder.GroupAnagrams(inputWords);

        // Assert
        groupedAnagrams.Should().BeEquivalentTo(
            new List<List<string>>
            {
                new() { "abc", "bac", "cba" },
                new() { "fun", "unf" },
                new() { "hello" }
            });
    }

    [Test]
    public void ShouldHandleCaseInsensitiveAnagrams()
    {
        // Arrange
        string[] inputWords = { "abc", "cAb", "cba" };

        // Act
        var groupedAnagrams = _anagramFinder.GroupAnagrams(inputWords);

        // Assert
        groupedAnagrams.Should().BeEquivalentTo(
            new List<List<string>>
            {
                new() { "abc", "cAb", "cba" }
            });
    }

    [Test]
    public void ShouldHandleSpecialCharactersInWords()
    {
        // Arrange
        string[] inputWords = { "abc", "cab!", "!bca" };

        // Act
        var groupedAnagrams = _anagramFinder.GroupAnagrams(inputWords);

        // Assert
        groupedAnagrams.Should().BeEquivalentTo(
            new List<List<string>>
            {
                new() { "abc" },
                new() { "cab!", "!bca" }
            });
    }

    [Test]
    public void ShouldReturnEmptyListForEmptyInput()
    {
        // Arrange
        var inputWords = Array.Empty<string>();

        // Act
        var groupedAnagrams = _anagramFinder.GroupAnagrams(inputWords);

        // Assert
        groupedAnagrams.Should().BeEmpty();
    }

    [Test]
    public void ShouldReturnSingleWordGroupForSingleWordInput()
    {
        // Arrange
        string[] inputWords = { "hello" };

        // Act
        var groupedAnagrams = _anagramFinder.GroupAnagrams(inputWords).ToList();

        // Assert
        groupedAnagrams.Should().HaveCount(1);
        groupedAnagrams.First().Should().ContainSingle().Which.Should().Be("hello");
    }

    [Test]
    public void ShouldHandleNullInput()
    {
        // Arrange
        string[] inputWords = null;

        // Act
        Action action = () => _anagramFinder.GroupAnagrams(inputWords);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }
}