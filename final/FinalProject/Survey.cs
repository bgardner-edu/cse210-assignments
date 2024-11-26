public static class Survey
{
    private static List<string> _questions = ["Do you have work to do items?", "Do you have school to do items?", "Do you have home repair to do items?", "Do you have vehicle to do items?"];
    private static List<int> _results = [];
    public static List<int> TakeSurvey()
    {
        Console.WriteLine("Answer the following questions with either y for yes or n for no: ");
        foreach (string question in _questions)
        {
            Console.WriteLine(question);
            var result = Console.ReadLine().ToLower();

            if (result == "y" || result == "yes")
            {
                _results.Add(_questions.IndexOf(question));
            }
        }
        return _results;
    }
    public static List<int> GetResults()
    {
        return _results;
    }
    public static void SetResults(List<int> results)
    {
        if (results.Count < 1)
        {
            _results = results;
        }
        else
        {
            Console.WriteLine("Cannot update survey results when they're already set.");
        }
    }
}