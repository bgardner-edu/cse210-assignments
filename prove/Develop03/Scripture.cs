using System.Security.Cryptography;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words; 
    private List<int> _noneBlankWords;

    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
        _noneBlankWords = [];
        for (int i = 0; i < words.Count; i++ )
        {
            _noneBlankWords.Add(i);
        }
    }
    public void DisplayScripture()
    {
        _reference.DisplayReference();

        int count = 0;
        foreach(Word word in _words)
        {
            count++;
            word.DisplayWord();
            if(count > 5)
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
        while(count < 5)
        {
            Random random = new Random();
            var num = random.Next(0, _noneBlankWords.Count);
            _words[_noneBlankWords[num]].SetVisible(false);
            _noneBlankWords.RemoveAt(num);
            count++;
            if(_noneBlankWords.Count == 0)
            {
                wordsLeft = false;
                break;
            }
        }
        return wordsLeft;
    }
}