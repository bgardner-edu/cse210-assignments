using System.Xml.XPath;

public static class Data
{
    public static void SaveSurveyResults(string username, string contents)
    {
        File.WriteAllText($"{username}_survey.txt", contents);
    }
    public static void SaveToDos(string username, string contents)
    {
        File.WriteAllText($"{username}_todo.txt", contents);
    }

    public static User SetupUser(string name)
    {
        var surveyFile = $"{name}_survey.txt";
        var toDoFile = $"{name}_todo.txt";
        if (File.Exists(surveyFile))
        {
            var survey = File.ReadAllText(surveyFile);

            if(File.Exists(toDoFile))
            {
                var toDo = File.ReadAllText(toDoFile);
                return new User(name, survey, toDo);
            }
            
            return  new User(name, survey);
        }

        return new User(name);
    }
}