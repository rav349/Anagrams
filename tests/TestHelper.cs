using codingtest;
using codingtest.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace tests;

internal class TestHelper
{
    public static void RunConsoleApp(string[]? arguments = default)
    {
        try
        {
            var mockAnagramFinder = new Mock<IAnagramFinder>();
            var serviceProvider = new ServiceCollection()
                .AddTransient<IAnagramFinder>(_ => mockAnagramFinder.Object)
                .BuildServiceProvider();

            var entryPoint = typeof(AnagramFinder).Assembly.EntryPoint!;
            entryPoint.Invoke(null, new object[] { arguments ?? Array.Empty<string>() });
        }
        catch (System.Reflection.TargetInvocationException e)
        {
            throw e.InnerException ?? e;
        }
    }

    public static string[] CapturedStdOut(Action callback)
    {
        var originalStdOut = Console.Out;

        using var newStdOut = new StringWriter();
        Console.SetOut(newStdOut);

        callback.Invoke();
        var capturedOutput = newStdOut.ToString();

        Console.SetOut(originalStdOut);

        return capturedOutput.Replace("\r", "")
            .Split("\n", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    }
}