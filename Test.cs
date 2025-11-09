namespace Thesaurus;

/*
 * In a larger project this class would be replaced by proper unit tests
 * implemented using a testing framework such as xUnit.
*/

public class Test
{
    public static void RunAll()
    {
        AddSynonyms_ShouldThrowArgumentExceptionOnSingleWord();
        GetWords_ShouldReturnAllAddedWords();
        GetSynonyms_ShouldGetAllSynonyms();
        GetSynonyms_ShouldReturnEmpty();
    }

    /// <summary>
    /// Test Case: It should not be possible to add a single word since it takes at least two words for synonyms.
    /// Expected: AddSynonyms() should throw ArgumentException on single word.
    /// </summary>
    public static void AddSynonyms_ShouldThrowArgumentExceptionOnSingleWord()
    {
        // Arrange
        IThesaurus thesaurus = new SimpleThesaurus();

        // Act & Assert
        try
        {
            thesaurus.AddSynonyms(new List<string> { "flitig" });
            Console.WriteLine("[FAIL] AddSynonyms_ShouldThrowArgumentExceptionOnSingleWord (no exception)");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("[PASS] AddSynonyms_ShouldThrowArgumentExceptionOnSingleWord");
        }
        catch (Exception)
        {
            Console.WriteLine("[FAIL] AddSynonyms_ShouldThrowArgumentExceptionOnSingleWord (wrong exception");
        }
    }

    /// <summary>
    /// Test Case: When adding multiple synonym lists GetWords() should return all words regardless of what
    ///     list they belong to.
    /// Expected: GetWords() should return all words in the list no matter what synonym list it is connected to.
    /// </summary>
    public static void GetWords_ShouldReturnAllAddedWords()
    {
        // Arrange
        IThesaurus thesaurus = new SimpleThesaurus();
        
        // Act
        thesaurus.AddSynonyms(new List<string> {"stor", "enorm", "gigantisk"});
        thesaurus.AddSynonyms(new List<string> { "glad", "lycklig", "upprymd" });
        
        // Assert
        var words = thesaurus.GetWords().ToList();
        bool allExists = words.Contains("stor")
                         && words.Contains("enorm")
                         && words.Contains("gigantisk")
                         && words.Contains("glad")
                         && words.Contains("lycklig")
                         && words.Contains("upprymd");

        Console.WriteLine(allExists 
            ? "[PASS] GetWords_ShouldReturnAllAddedWords()" 
            : "[FAIL] GetWords_ShouldReturnAllAddedWords");
    }

    /// <summary>
    /// Test Case: All synonyms in a synonym list should be connected to each other.
    /// Expected: GetSynonyms() should return all synonyms for one word in a synonym list.
    /// </summary>
    public static void GetSynonyms_ShouldGetAllSynonyms()
    {
        // Arrange
        IThesaurus thesaurus = new SimpleThesaurus();
        var words = new List<string> {"stor", "enorm", "gigantisk"};

        // Act
        thesaurus.AddSynonyms(words);

        // Assert
        bool allIsLinked = true;
        foreach (var word in words)
        {
            var synonyms = thesaurus.GetSynonyms(word).ToList();
            var expectedSynonyms = words.Where(w => w != word);
            if (!expectedSynonyms.All(e => synonyms.Contains(e)))
            {
                allIsLinked = false;
                break;
            }
        }

        Console.WriteLine(allIsLinked 
            ? "[PASS] GetSynonyms_ShouldGetAllSynonyms()" 
            : "[FAIL] GetSynonyms_ShouldGetAllSynonyms()");
    }

    /// <summary>
    /// Test Case: When searching for synonyms to a word non should be returned if synonyms are not found.
    /// Expected: GetSynonyms() should return an empty list if no synonyms are found.
    /// </summary>
    public static void GetSynonyms_ShouldReturnEmpty()
    {
        // Arrange
        IThesaurus thesaurus = new SimpleThesaurus();
        thesaurus.AddSynonyms(new List<string> {"stor", "enorm", "gigantisk"});
        
        // Act
        var result = thesaurus.GetSynonyms("liten");

        // Assert
        if (!result.Any())
        {
            Console.WriteLine("[PASS] GetSynonyms_ShouldReturnEmptyString()");
        }
        else
        {
            Console.WriteLine("[FAIL] GetSynonyms_ShouldReturnEmptyString()");
        }
    }
}