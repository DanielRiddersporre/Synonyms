namespace Thesaurus;

class Program
{
    static void Main()
    {
        // Running all tests
        Console.WriteLine("\n=== Testresultat ===");
        Test.RunAll();
        
        // Change word to find synonyms. Solution is case-insensitive
        string searchWord = "StOr";
        
        IThesaurus simpleThesaurus = new SimpleThesaurus();

        // Create lists of synonyms. Create as many as you want.
        simpleThesaurus.AddSynonyms(new List<string> { "stor", "enorm", "gigantisk" });
        simpleThesaurus.AddSynonyms(new List<string> { "snabb", "kvick" });

        // Print all words from the created synonyms above
        Console.WriteLine("\n=== Alla ord ===");
        foreach (var word in simpleThesaurus.GetWords())
            Console.WriteLine($" - {word}");

        // Print all synonyms to the "SearchWord"
        Console.WriteLine($"\n=== Synonymer till '{searchWord}' (Case Insensitive) ===");
        foreach (var syn in simpleThesaurus.GetSynonyms(searchWord))
            Console.WriteLine($" - {syn}");
    }
}
