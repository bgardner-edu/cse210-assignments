using System.Globalization;

public class User
{
    private string _name;
    private List<ToDo> _toDoList;
    private List<string> _surveyResult;
    public User(string name)
    {
        _name = name;
        _surveyResult = Survey.TakeSurvey(name);
    }
    public User(string name, string survey)
    {
        _name = name;
        _surveyResult = Survey.ParseSurvey(survey);
    }
    public User(string name, string surveyResults, string toDos)
    {
        _name = name;
        _surveyResult = Survey.ParseSurvey(surveyResults);
        _toDoList = ParseToDos(toDos);
    }
    public string GetName()
    {
        return _name;
    }
    public void CreateNewItem()
    {
        Console.WriteLine($"Which To Do type would you like to create?");
        foreach (string result in _surveyResult)
        {
            Console.WriteLine($"{result}");
        }
        var option = Console.ReadLine().ToLower();

        Console.Write("What do you need to do?  ");
        var name = Console.ReadLine();

        Console.Write("When do you need to complete it? Enter date like mm-dd");
        var completeByString = Console.ReadLine();
        var completeByDate = DateTime.ParseExact(completeByString, "MM-dd", CultureInfo.InvariantCulture);

        //Fix this...
        Console.Write("Does it depend on another to do item? ");
        var dependsOn = int.Parse(Console.ReadLine());

        switch (option)
        {
            case "work":
                WorkToDo wtd = new WorkToDo(name, completeByDate, dependsOn);
                _toDoList.Add(wtd);
                break;
            case "school":
                SchoolToDo std = new SchoolToDo(name, completeByDate, dependsOn);
                _toDoList.Add(std);
                break;
            case "home":
                HomeToDo htd = new HomeToDo(name, completeByDate, dependsOn);
                _toDoList.Add(htd);
                break;
            case "car":
                VehicleToDo vtd = new VehicleToDo(name, completeByDate, dependsOn);
                _toDoList.Add(vtd);
                break;
            default:
                break;
        }
    }
    public void ListItemsByDate()
    {
        
    }
    public void ListItemsByType()
    {

    }
    public void MarkItemCompleted()
    {

    }
    private void Save()
    {

    }
    private List<ToDo> ParseToDos(string toDos)
    {
        return null;
    }
}