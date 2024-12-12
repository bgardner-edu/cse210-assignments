public static class Survey
{
    private static Dictionary<string, string> _questions = new Dictionary<string, string>
    {
        {"Do you have work to do items?", "Work"},
        {"Do you have school to do items?","School"},
        {"Do you have home repair to do items?", "Home"},
        {"Do you have vehicle to do items?", "Car"},
        {"Do you want general to do items", "General"},
    };
    private static List<string> _results = [];
    public static List<string> TakeSurvey(string name)
    {
        Console.WriteLine("Answer the following questions with either y for yes or n for no: ");
        foreach (string question in _questions.Keys)
        {
            Console.WriteLine(question);
            var result = Console.ReadLine().ToLower();

            if (result == "y" || result == "yes")
            {
                _results.Add(_questions[question]);
            }
        }
        SaveSurvey(name, _results);
        return _results;
    }
    public static List<string> GetResults()
    {
        return _results;
    }
    public static void SetResults(List<string> results)
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
    public static List<string> ParseSurvey(string contents)
    {
        var results = contents.Split("\n");
        List<string> surveyResults = [];
        foreach (string result in results)
        {
            if (result != "")
            {
                surveyResults.Add(result);
            }
        }
        return surveyResults;
    }
    private static void SaveSurvey(string name, List<string> results)
    {
        var contents = "";
        foreach (string result in results)
        {
            contents += $"{result}\n";
        }
        SaveSurveyResults(name, contents);
    }
    public static void SaveSurveyResults(string username, string contents)
    {
        File.WriteAllText($"{username}_survey.txt", contents);
    }

}