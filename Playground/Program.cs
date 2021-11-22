using Playground;

Console.WriteLine("Hello, World!");

var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var strings = new[] { "zero", "one", "two", "three", 
                        "four", "five", "six", "seven",
                        "eight", "nine" };

// 1 strings - pomocí LINQu vytvořte nové pole kde jsou všechna slova uppercase
//var result = strings.Select(x => x.ToUpper());

// 2 numbers - zjiste pomoci LINQu jestli pole obsahuje pouze suda cisla
//bool isOnlyEvenNumbers = numbers.All(x => x % 2 == 0);
//global::System.Console.WriteLine($"jsou vsechna cisla suda: {isOnlyEvenNumbers}");

// 3 - vypište čísla v poli numbers jako slova - LINQ
// var result = numbers.Select(x => strings[x]);

// 4 - zjistěte kolik obsahují všechna
// slova v poli "strings" dohromady písmen - LINQ
// var sumletters = strings.Select(x => x.Length).Sum();
// Console.WriteLine($"vsechna slova v poli strings maji dohromady {sumletters} pismen");

// 5 - vytvořte novou kolekci obsahující dvojici
// lowercase i uppercase variantu
//var result = strings
//            .Select(slovo => new UpperLowerString(slovo))
//            .Select(x => $"upper:{x.UpperCase} lower:{x.LowerCase}");

// - 5 pomoci tuplu
// var result = strings.Select(slovo => (slovo.ToLower(), slovo.ToUpper()));

// 6 - LINQ - frekvence vyskytu jednotlivych pismen ve vsech
// polozkach pole strings (kombinovane - v celem poli)

// agregace - https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate?view=net-6.0
//var res = strings.Aggregate(
//   "", // start with empty string to handle empty list case.
//   (agg, item) => agg + item);
//Console.WriteLine(res);

<<<<<<< HEAD
<<<<<<< HEAD
var aggregated = string.Join("", strings); //spojim slova do jednoho retece
var result = aggregated // pracuji se stringem jako s kolekci znaku
    .GroupBy(x => x) // seskupuji podle pismenek (char v koleci string)
    .Select(g => (Letter: g.Key,Count: g.Count())) // udelam tuple obsahujici klic (pismenko) a pocet prvku
    .OrderBy(x => x.Count)
    .ThenByDescending(x => x.Letter)
    ;
=======
=======
>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43
//var aggregated = string.Join("", strings); //spojim slova do jednoho retece
//var result = aggregated // pracuji se stringem jako s kolekci znaku
//    .GroupBy(x => x) // seskupuji podle pismenek (char v koleci string)
//    .Select(g => (Letter: g.Key,Count: g.Count())) // udelam tuple obsahujici klic (pismenko) a pocet prvku
//    .OrderBy(x => x.Count)
//    .ThenByDescending(x => x.Letter)
//    ; 
<<<<<<< HEAD
=======

// Dictionary - https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0

>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43

// Dictionary - https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0

<<<<<<< HEAD
>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43
=======
var dict = CharFreq("abrakadabra");

Console.WriteLine();

>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43

//var dict = CharFreq("abrakadarbra");
//Console.WriteLine();

<<<<<<< HEAD
<<<<<<< HEAD
//PrintList(result.ToList())
//PrintItems<(char, int)>(result);

foreach(var file in Directory.GetFiles("Books"))
{
    var countWords = TopTenWords(File.ReadAllText(file));
}

static Dictionary<string, int> TopTenWords(string fileString)
{
    var wordsCount = fileString.Split(" ").GroupBy(x => x).Select(g => (Word: g.Key, Count: g.Count())).OrderByDescending(p => p.Count).Take(10);
    Dictionary<string, int> dict = new Dictionary<string, int>();
    foreach (var tuple in wordsCount)
    {
        dict.Add(tuple.Word, tuple.Count);
    }

    return dict;
}
=======
var dict = CharFreq("abrakadabra");

Console.WriteLine();

>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43


<<<<<<< HEAD
=======
//PrintItems<(char, int)>(result);
>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43
=======
//PrintItems<(char, int)>(result);
>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43


foreach (var file in Directory.GetFiles("Books"))
{
    var countWords = TopTenWords(File.ReadAllText(file));
}

static Dictionary<string, int> TopTenWords(string fileString)
{
    var wordsCount = fileString.Split(" ").GroupBy(x => x).Select(g => (Word: g.Key, Count: g.Count())).OrderByDescending(p => p.Count).Take(10);
    Dictionary<string, int> dict = new Dictionary<string, int>();
    foreach (var tuple in wordsCount)
    {
        dict.Add(tuple.Word, tuple.Count);
    }

    return dict;
}


static void PrintList(List<string> listToPrint)
{
    foreach (var item in listToPrint)
    {
        Console.WriteLine(item);
    }
}

static void PrintItems<T>(IEnumerable<T> items)
{
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static Dictionary<char, int> CharFreq(string input)
{
<<<<<<< HEAD
<<<<<<< HEAD
    var tuples = input.GroupBy(x => x)
   .Select(g => (Letter: g.Key, Count: g.Count())) // udelam tuple obsahujici klic (pismenko) a pocet prvku
   .OrderBy(x => x.Count)
   .ThenByDescending(x => x.Letter);


    Dictionary<char, int> dict = new Dictionary<char, int>();
    foreach (var tuple in tuples)
    {
        dict.Add(tuple.Letter,tuple.Count);
=======
=======
>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43
    var tuples = input.GroupBy(x => x) // seskupuji podle pismenek (char v koleci string)
    .Select(g => (Letter: g.Key, Count: g.Count())) // udelam tuple obsahujici klic (pismenko) a pocet prvku
    .OrderBy(x => x.Count)
    .ThenByDescending(x => x.Letter);

    Dictionary<char, int> dict = new Dictionary<char, int>();

    foreach (var tuple in tuples)
    {
        dict.Add(tuple.Letter, tuple.Count);
<<<<<<< HEAD
>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43
=======
>>>>>>> 029be2d38cb49fc17e812a5ead57a3644acf1c43
    }

    return dict;
}