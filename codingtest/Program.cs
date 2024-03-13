using codingtest.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace codingtest;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0 || args.Length > 1 || string.IsNullOrWhiteSpace(args[0]))
                throw new ArgumentException(
                    "Please ensure that the input file is provided as the first and only parameter");

            if (!File.Exists(args[0])) throw new FileNotFoundException($"{args[0]} does not exist");

            var serviceProvider = new ServiceCollection()
                .AddTransient<IAnagramFinder, AnagramFinder>()
                .BuildServiceProvider();

            var anagramFinder = serviceProvider.GetService<IAnagramFinder>() ?? throw new Exception();

            var groupedAnagrams = anagramFinder.FindAnagrams(args[0]);

            foreach (var anagramGroup in groupedAnagrams) Console.WriteLine(string.Join(",", anagramGroup));
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            throw;
        }
    }
}