using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Reference reference;
        string text;
        try
        {
            BOM bom = LoadScriptures();

            Console.WriteLine("Would you like to choose a scripture? y/n");
            var choose = Console.ReadLine();
            if (choose == "y" || choose == "yes")
            {
                Console.WriteLine("Enter a book by entering a value between 1 - 15: ");
                var bookIndex = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Enter the chapter: ");
                var chapterIndex = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Enter the verse: ");
                var verseIndex = int.Parse(Console.ReadLine()) - 1;

                (reference, text) = bom.GetScripture(bookIndex, chapterIndex, verseIndex);
            }
            else
            {
                (reference, text) = bom.GetRandomScripture();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Failed to get scripture, using default...");
            reference = new Reference("1st Nephi", 3, 7);
            text = "I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them";
        }

        Scripture scripture = new Scripture(reference, text);

        bool run = true;
        bool wordsLeft = true;
        while (run)
        {
            
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("\n\nPress enter to continue or type 'quit' to finish");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                run = false;
            }
            else
            {
                if (wordsLeft)
                {
                    wordsLeft = scripture.RemoveRandomWords();
                }
                else
                {
                    run = false;
                }
                
            }
        }

    }
    public static BOM LoadScriptures()
    {
        //json file from: https://github.com/bcbooks/scriptures-json/tree/master
        var json = File.ReadAllText("book-of-mormon.json");
        var scriptures = JsonSerializer.Deserialize<BOM>(json);
        Console.WriteLine("Successfully loaded the book of mormon");
        return scriptures;
    }
}