public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = startVerse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    public void DisplayReference()
    {
        string fullVerse;
        if (_startVerse == _endVerse)
        {
            fullVerse = _startVerse.ToString();
        }
        else
        {
            fullVerse = $"{_startVerse}-{_endVerse}";
        }
        Console.WriteLine($"{_book} {_chapter}:{fullVerse}");
    }
}