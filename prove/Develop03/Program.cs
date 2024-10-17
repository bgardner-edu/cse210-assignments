using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("1st Nephi", 3, 7);
        List<Word> words = [];
        string text = "I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them";
        var textList = text.Split(" ");
        foreach (string t in textList)
        {
            Word word = new Word(t);
            words.Add(word);
        }
        Scripture scripture = new Scripture(reference, words);

        bool run = true;
        while (run)
        {
            scripture.DisplayScripture();
            //Write the UI for this. 
            Console.WriteLine("\n\nPress enter to continue or type 'quit' to finish");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                run = false;
            }
            else
            {
                bool wordsLeft = scripture.RemoveRandomWords();
                if (!wordsLeft)
                {
                    run = false;
                }
                else
                {
                    //This is broken...
                    //Console.Clear();
                }
            }
        }

    }
}