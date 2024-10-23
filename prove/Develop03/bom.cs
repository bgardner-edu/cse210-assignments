//I generated most of this file using visual studio 2022 and the book-of-mormon.json file
//https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/deserialization

public class BOM
{
    public Book[] books { get; set; }
    public string last_modified { get; set; }
    public string lds_slug { get; set; }
    public string subtitle { get; set; }
    public Testimony[] testimonies { get; set; }
    public string title { get; set; }
    public Title_Page title_page { get; set; }
    public int version { get; set; }

    public (Reference, string) GetRandomScripture()
    {
        Random random = new Random();
        var bookIndex = random.Next(0, books.Length);
        var chapterIndex = random.Next(0, books[bookIndex].chapters.Length);
        var verseIndex = random.Next(0, books[bookIndex].chapters[chapterIndex].verses.Length);
        return GetScripture(bookIndex, chapterIndex, verseIndex);
    }
    public (Reference, string) GetScripture(int bookIndex, int chapterIndex, int verseIndex)
    {
        var book = books[bookIndex].book;
        var chapter = books[bookIndex].chapters[chapterIndex].chapter;
        var verse = books[bookIndex].chapters[chapterIndex].verses[verseIndex].verse;
        var reference = new Reference(book, chapter, verse);
        var text = books[bookIndex].chapters[chapterIndex].verses[verseIndex].text;
        return (reference, text);
    }
}

public class Title_Page
{
    public string subtitle { get; set; }
    public string[] text { get; set; }
    public string title { get; set; }
    public string translated_by { get; set; }
}

public class Book
{
    public string book { get; set; }
    public Chapter[] chapters { get; set; }
    public string full_title { get; set; }
    public string heading { get; set; }
    public string lds_slug { get; set; }
    public string full_subtitle { get; set; }
}

public class Chapter
{
    public int chapter { get; set; }
    public string reference { get; set; }
    public Vers[] verses { get; set; }
    public string heading { get; set; }
}

public class Vers
{
    public string reference { get; set; }
    public string text { get; set; }
    public int verse { get; set; }
}

public class Testimony
{
    public string text { get; set; }
    public string title { get; set; }
    public string[] witnesses { get; set; }
}
