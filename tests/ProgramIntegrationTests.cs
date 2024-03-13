namespace tests;

public class ProgramIntegrationTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldReturnInputFileRequiredNoArgumentsPresent()
    {
        var exception = Assert.Throws<System.ArgumentException>(() => TestHelper.RunConsoleApp());
        Assert.That(exception!.Message, Is.EqualTo("Please ensure that the input file is provided as the first and only parameter"));
    }

    [Test]
    public void ShouldReturnInputFileRequiredIfMoreThan1ArgumentsPresent()
    {
        var exception = Assert.Throws<System.ArgumentException>(() => TestHelper.RunConsoleApp(new[] { "one", "two" }));
        Assert.That(exception!.Message, Is.EqualTo("Please ensure that the input file is provided as the first and only parameter"));
    }

    [Test]
    public void ShouldReturnInputFileDoesNotExist()
    {
        const string filename = "abc.txt";
        var exception = Assert.Throws<FileNotFoundException>(() => TestHelper.RunConsoleApp(new[] { filename }));
        Assert.That(exception!.Message, Is.EqualTo($"{filename} does not exist"));

    }
}