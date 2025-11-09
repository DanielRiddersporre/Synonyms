namespace Thesaurus;
public class SimpleThesaurus : IThesaurus
{
    private readonly Dictionary<string, HashSet<string>> _synonyms
        = new(StringComparer.OrdinalIgnoreCase);

    public void AddSynonyms(IEnumerable<string> synonyms)
    {
        // Handle empty list of synonyms
        if (synonyms == null) throw new ArgumentNullException(nameof(synonyms));
        
        var list = synonyms
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
        
        // Handle too few words in added synonyms
        if (list.Count < 2)
            throw new ArgumentException("At least two words required to define synonyms.");

        foreach (var word in list)
        {
            if (!_synonyms.ContainsKey(word))
                _synonyms[word] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var other in list)
            {
                if (!string.Equals(word, other, StringComparison.OrdinalIgnoreCase))
                    _synonyms[word].Add(other);
            }
        }
    }

    public IEnumerable<string> GetSynonyms(string word)
        => _synonyms.TryGetValue(word, out var set) ? set : Enumerable.Empty<string>();

    public IEnumerable<string> GetWords() => _synonyms.Keys.OrderBy(word => word);
}