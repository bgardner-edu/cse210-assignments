using System.Globalization;

public class User
{
    private string _name;
    private List<ToDo> _toDoList = [];
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
    public string GetName2()
    {
        return _name;
    }
    public string GetName3()
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
        //Console.Write("Does it depend on another to do item? y/n ");
        var dependsOn = 0;//int.Parse(Console.ReadLine());

        switch (option)
        {
            case "general":
                ToDo td = new ToDo(name, completeByDate, dependsOn);
                _toDoList.Add(td);
                Save();
                break;
            case "work":
                WorkToDo wtd = new WorkToDo(name, completeByDate, dependsOn);
                _toDoList.Add(wtd);
                Save();
                break;
            case "school":
                SchoolToDo std = new SchoolToDo(name, completeByDate, dependsOn);
                _toDoList.Add(std);
                Save();
                break;
            case "home":
                HomeToDo htd = new HomeToDo(name, completeByDate, dependsOn);
                _toDoList.Add(htd);
                Save();
                break;
            case "car":
                VehicleToDo vtd = new VehicleToDo(name, completeByDate, dependsOn);
                _toDoList.Add(vtd);
                Save();
                break;
            default:
                break;
        }
    }
    public void ListItemsByDate(bool completed = false)
    {
        var filteredItems = _toDoList.FindAll(t => t.GetCompleted() == completed);
        var sortedByDate = _toDoList.OrderBy(t => t.GetDateTime()).ToList();
        foreach (ToDo item in sortedByDate)
        {
            item.ListToDoItem();
            Console.WriteLine();
        }
        Console.WriteLine("Press Enter to continue: ");
        Console.ReadLine();
    }
    public void ListItemsByType(bool completed = false)
    {
        var type = "";
        Console.WriteLine($"Which To Do type would you like to create?");
        foreach (string result in _surveyResult)
        {
            Console.WriteLine($"{result}");
        }

        var option = Console.ReadLine().ToLower();

        switch (option)
        {
            case "general":
                type = "ToDo";
                break;
            case "work":
                type = "WorkToDo";
                break;
            case "school":
                type = "SchoolToDo";
                break;
            case "home":
                type = "HomeToDo";
                break;
            case "car":
                type = "VehicleToDo";
                break;
            default:
                break;
        }

        var filteredItems = _toDoList.FindAll(t => t.GetCompleted() == completed);
        var sortedByType = _toDoList.FindAll(t => t.GetType().ToString() == type).ToList();
        foreach (ToDo item in sortedByType)
        {
            item.ListToDoItem();
            Console.WriteLine();
        }
        Console.WriteLine("Press Enter to continue: ");
        Console.ReadLine();
    }
    public void MarkItemCompleted()
    {
        //Finish This!
    }
    private void Save()
    {
        var content = "";
        foreach (ToDo todo in _toDoList)
        {
            content += $"{todo.Save()}\n";
        }
        Data.SaveToDos(_name, content);
    }
    private List<ToDo> ParseToDos(string toDos)
    {
        List<ToDo> todos = new List<ToDo>();
        var lines = toDos.Split('\n');
        foreach (string item in lines)
        {
            var data = item.Split("||");
            switch (data[0])
            {
                case "td":
                    ToDo td = new ToDo(data[1], data[2], DateTime.Parse(data[3]), int.Parse(data[4]), bool.Parse(data[5]));
                    todos.Add(td);
                    break;
                case "wtd":
                    WorkToDo wtd = new WorkToDo(data[1], data[2], DateTime.Parse(data[3]), int.Parse(data[4]), bool.Parse(data[5]), data[6]);
                    todos.Add(wtd);
                    break;
                case "std":
                    SchoolToDo std = new SchoolToDo(data[1], data[2], DateTime.Parse(data[3]), int.Parse(data[4]), bool.Parse(data[5]), data[6]);
                    todos.Add(std);
                    break;
                case "vtd":
                    VehicleToDo vtd = new VehicleToDo(data[1], data[2], DateTime.Parse(data[3]), int.Parse(data[4]), bool.Parse(data[5]), data[6].Split(',').ToList());
                    todos.Add(vtd);
                    break;
                case "htd":
                    HomeToDo htd = new HomeToDo(data[1], data[2], DateTime.Parse(data[3]), int.Parse(data[4]), bool.Parse(data[5]), data[6].Split(',').ToList(), bool.Parse(data[7]));
                    todos.Add(htd);
                    break;
                default:
                    break;
            }
        }
        return todos;
    }
}