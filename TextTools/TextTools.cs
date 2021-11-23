namespace TextTools
{
    public class TextTools
    {   
        public static Dictionary<string, int> TopTenWords(string fileString, string splitBy = " ")
        {
            var wordsCount = fileString.Split(splitBy).GroupBy(x => x).Select(g => (Word: g.Key, Count: g.Count())).OrderByDescending(p => p.Count).Take(10);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var tuple in wordsCount)
            {
                dict.Add(tuple.Word, tuple.Count);
            }

            return dict;
        }
    }
}