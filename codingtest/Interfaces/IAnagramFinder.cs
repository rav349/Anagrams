namespace codingtest.Interfaces;

public interface IAnagramFinder
{
    IEnumerable<IEnumerable<string>> FindAnagrams(string filename);
    IEnumerable<string> ReadUniqueWordsFromFile(string filename);
    IEnumerable<IEnumerable<string>> GroupAnagrams(IEnumerable<string> words);
}