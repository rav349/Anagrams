using codingtest.Interfaces;

namespace codingtest;

public class AnagramFinder : IAnagramFinder
{
    public IEnumerable<IEnumerable<string>> FindAnagrams(string filename)
    {
        var words = ReadUniqueWordsFromFile(filename);
        return GroupAnagrams(words);
    }

    public IEnumerable<string> ReadUniqueWordsFromFile(string filename)
    {
        if (!File.Exists(filename)) throw new FileNotFoundException($"File '{filename}' not found");

        var uniqueWords = new HashSet<string>();

        using (var reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
                if (uniqueWords.Add(line))
                    yield return line;
        }
    }

    public IEnumerable<IEnumerable<string>> GroupAnagrams(IEnumerable<string> words)
    {
        if (words is null) throw new ArgumentNullException();

        var groupedAnagrams = new List<List<string>>();
        var anagramDictionary = new Dictionary<string, List<string>>();

        foreach (var word in words)
        {
            var lowerCaseWord = word.ToLower();

            var alphabeticallySortedWord = string.Concat(lowerCaseWord.OrderBy(c => c));
            if (anagramDictionary.ContainsKey(alphabeticallySortedWord))
            {
                anagramDictionary[alphabeticallySortedWord].Add(word);
            }
            else
            {
                var newGroup = new List<string> { word };
                anagramDictionary.Add(alphabeticallySortedWord, newGroup);
                groupedAnagrams.Add(newGroup);
            }
        }

        return groupedAnagrams;
    }
}