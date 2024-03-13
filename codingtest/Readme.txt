I have create a solution which takes in a filepath to a file which contains one word per line and will return an output to the console that would group together all anagrams a in comma separated list. 

The code can be run by the following command
"dotnet <path to codingtest.dll> <path to text file>"

Big O Complexity 
My program iterates through each word in the IEnumerable<string> words passed to the GroupAnagrams method. For each word it ToLowers the word and then sorts the characters alphabetically. This means we must iterate through every character of every word. Our worst time complexity is O(n log(n)) where the length of our list is also the length of each word

Data structures 
I have used HashSet<T> when reading words out of the file as it is the best way to handle duplcates in a list where we disregard duplicates. I have used this so if we happen to have a duplcate, we do not waste any more computation on that item and simply move onto the next rather than replace the old with new value.  
Each anagram group is sorted into a Dictionary<string, List<string>> which allows us to create a key and O(1) retrieval of a Key-Value-Pair.
I am returning IEnumerable from FindAnagrams as I do not want the output value to be changed before returning to user. If this needs to be done then the output must be converted into a List. Doing so should mean that the next developer maintaining the code will need to think about why they are editing the output.

If I had more time I would like to flesh out and add more edge cases tests. I would've also liked to spend a little more time on the case-sensitivity of the solution. I am not a fan of toLower/toUpper due to its lack of intent and performance impact, rather I would implement string.Equals as I would not have to create another string. I would've also split out the file reading separate so I could make that a more testable unit and also separate the reading of a file and finding of anagrams