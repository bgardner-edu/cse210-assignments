public class Word
{
    private string _word;
    private bool _visible;

    public Word(string word)
    {
        _word = word;
        _visible = true;
    }
    public void DisplayWord()
    {
        if (_visible)
        {
            Console.Write($"{_word} ");
            return;
        }
        string blank = "";
        foreach (char c in _word)
        {
            blank += "_";
        }
        Console.Write($"{blank} ");
    }
    public bool GetVisible()
    {
        return _visible;
    }
    public void SetVisible(bool visible)
    {
        _visible = visible;
    }
}