namespace Thesaurus;

class Program
{
    static void Main()
    {
        // Running all tests
        Test.RunAll();
        
        // Change word to find synonyms. Solution is case-insensitive
        string searchWord = "StOr";
        
        SimpleThesaurus simpleThesaurus = new();

        // Create lists of synonyms. Create as many as you want.
        simpleThesaurus.AddSynonyms(new List<string> { "stor", "enorm", "gigantisk" });
        simpleThesaurus.AddSynonyms(new List<string> { "snabb", "kvick" });

        // Print all words from the created synonyms above
        Console.WriteLine("\nAlla ord:");
        foreach (var word in simpleThesaurus.GetWords())
            Console.WriteLine($" - {word}");

        // Print all synonyms to the "SearchWord"
        Console.WriteLine($"\nSynonymer till {searchWord}:");
        foreach (var syn in simpleThesaurus.GetSynonyms(searchWord))
            Console.WriteLine($" - {syn}");
    }
}
