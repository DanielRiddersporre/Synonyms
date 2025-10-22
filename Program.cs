namespace Thesaurus;

class Program
{
    static void Main()
    {
        // Change word to find synonyms. Solution is case-insensitive
        string searchWord = "StOr";
        
        SimpleThesaurus simpleThesaurus = new();

        // Create lists of synonyms. Create as many as you want.
        simpleThesaurus.AddSynonyms(new List<string> { "stor", "enorm", "gigantisk" });
        simpleThesaurus.AddSynonyms(new List<string> { "snabb", "kvick" });
        
        // Error Showcase: To few words added to the list
        try
        {
            simpleThesaurus.AddSynonyms(new List<string> { "flitig" });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

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
