using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        //List<string> list = new List<string>() { "cat", "bob", "angel", "book", "abc"};
        List<string> list = new List<string>() { "кошка", "булочки", "ангел", "Река","книга", "ка","люстра","ток" };
        //List<string> list = new List<string>() { "к", "э", "аавмавмавмав"};
        var sort = ABCSortTest(list);
        foreach (var item in sort)
            Console.WriteLine(item);
    }
    public static List<string> ABSSort(List<string> words, int rank = 0)
    {
        if (words.Count <= 1)
            return words;
        List<string> wordsLower = words.ConvertAll(x => x.ToLower());
        var square = new Dictionary<char, List<string>>(62);
        var result = new List<string>();
        int shortWordsCounter = 0;
        foreach (var word in wordsLower)
        {
            if (rank < word.Length)
            {
                if (square.ContainsKey(word[rank]))
                    square[word[rank]].Add(word);
                else
                    square.Add(word[rank], new List<string> { word });
            }
            else
            {
                result.Add(word);
                shortWordsCounter++;
            }
        }
        if (shortWordsCounter == wordsLower.Count)
            return wordsLower;

        for (char i = 'а'; i <= 'я'; i++)
        {
            if (square.ContainsKey(i))
            {
                foreach (var word in ABSSort(square[i], rank + 1))
                    result.Add(word);
            }
        }
        return result;
    }

    public static List<string> ABCSortTest(List<string> words, int rank = 0)
    {
        if (words.Count <= 1)
            return words;
        List<string> wordsLower = words.ConvertAll(x => x.ToLower());
        Dictionary<char, List<string>> square = new Dictionary<char, List<string>>(62);
        List<string> result = new List<string>();
        foreach (string word in wordsLower)
        {
            if (square.ContainsKey(word[rank]))
            {
                square[word[rank]].Add(word);
            }
            else
            {
                square[word[rank]] = new List<string>() { word };
            }
        }
        
        for (char i = 'а'; i < 'я'; i++)
        {
            if (square.ContainsKey(i))
            {
                foreach (var item in ABCSortTest(square[i], rank + 1))
                    result.Add(item);
            }
        }
        return result;
    }
}