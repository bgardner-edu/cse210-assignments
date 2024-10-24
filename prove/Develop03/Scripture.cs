public class Scripture
{
    private Reference _reference;
    private List<Word> _words = [];
    private List<int> _noneBlankWords;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        var textList = text.Split(" ");
        foreach (string t in textList)
        {
            Word word = new Word(t);
            _words.Add(word);
        }
        _noneBlankWords = [];
        for (int i = 0; i < _words.Count; i++)
        {
            _noneBlankWords.Add(i);
        }
    }
    public void DisplayScripture()
    {
        _reference.DisplayReference();

        int count = 0;
        foreach (Word word in _words)
        {
            count++;
            word.DisplayWord();
            if (count > 6) // Display 6 words per line
            {
                count = 0;
                Console.Write("\n");
            }
        }
    }
    public bool RemoveRandomWords()
    {
        bool wordsLeft = true;
        int count = 0;
        while (count < 3)
        {
            //Only hide words that are not already hidden.
            Random random = new Random();
            var num = random.Next(0, _noneBlankWords.Count);
            _words[_noneBlankWords[num]].SetVisible(false);
            _noneBlankWords.RemoveAt(num);
            count++;
            if (_noneBlankWords.Count == 0)
            {
                wordsLeft = false;
                break;
            }
        }
        return wordsLeft;
    }
}