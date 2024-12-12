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

        var dependsOn = "";
        Console.Write("Does it depend on another to do item? y/n ");
        var input = Console.ReadLine();
        if (input == "y" || input == "yes")
        {
            dependsOn = GetDependsId();
        }

        switch (option)
        {
            case "general":
                ToDo td = new ToDo(name, completeByDate, dependsOn);
                _toDoList.Add(td);
                SaveToDos();
                break;
            case "work":
                WorkToDo wtd = new WorkToDo(name, completeByDate, dependsOn);
                _toDoList.Add(wtd);
                SaveToDos();
                break;
            case "school":
                SchoolToDo std = new SchoolToDo(name, completeByDate, dependsOn);
                _toDoList.Add(std);
                SaveToDos();
                break;
            case "home":
                HomeToDo htd = new HomeToDo(name, completeByDate, dependsOn);
                _toDoList.Add(htd);
                SaveToDos();
                break;
            case "car":
                VehicleToDo vtd = new VehicleToDo(name, completeByDate, dependsOn);
                _toDoList.Add(vtd);
                SaveToDos();
                break;
            default:
                break;
        }
    }
    public void ListItemsByDate(bool completed = false)
    {
        var filteredItems = _toDoList.FindAll(t => t.GetCompleted() == completed);
        var sortedByDate = filteredItems.OrderBy(t => t.GetDateTime()).ToList();
        foreach (ToDo item in sortedByDate)
        {
            item.ListToDoItem();
            Console.WriteLine();

            ToDo dependant = _toDoList.Find(t => t.GetId() == item.GetDependsOn());
            if (dependant != null)
            {
                Console.WriteLine($"\nThis Goal depends on:");
                dependant.ListToDoItem();
                Console.WriteLine();
            }
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
        var sortedByType = filteredItems.FindAll(t => t.GetType().ToString() == type).ToList();
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
        DisplayToDoListWithNum(_toDoList);
        Console.WriteLine("Enter the number for the goal you want to complete");
        var input = int.Parse(Console.ReadLine()) - 1;

        _toDoList[input].MarkAsDone();
        SaveToDos();
    }
    private string GetDependsId()
    {
        var filteredItems = _toDoList.FindAll(t => t.GetCompleted() == false);
        DisplayToDoListWithNum(filteredItems);
        Console.WriteLine("Enter the number for the to do item it depends on: ");
        var input = int.Parse(Console.ReadLine()) - 1;
        return filteredItems[input].GetId();
    }
    private void DisplayToDoListWithNum(List<ToDo> list)
    {
        var count = 1;

        foreach (ToDo item in list)
        {
            Console.Write($"{count}. ");
            item.ListToDoItem();
            Console.WriteLine();
            count++;
        }
    }
    private void SaveToDos()
    {
        var content = "";
        foreach (ToDo todo in _toDoList)
        {
            content += $"{todo.Save()}\n";
        }
        File.WriteAllText($"{_name}_todo.txt", content);
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
                    ToDo td = new ToDo(data[1], data[2], DateTime.Parse(data[3]), data[4], bool.Parse(data[5]));
                    todos.Add(td);
                    break;
                case "wtd":
                    WorkToDo wtd = new WorkToDo(data[1], data[2], DateTime.Parse(data[3]), data[4], bool.Parse(data[5]), data[6]);
                    todos.Add(wtd);
                    break;
                case "std":
                    SchoolToDo std = new SchoolToDo(data[1], data[2], DateTime.Parse(data[3]), data[4], bool.Parse(data[5]), data[6]);
                    todos.Add(std);
                    break;
                case "vtd":
                    VehicleToDo vtd = new VehicleToDo(data[1], data[2], DateTime.Parse(data[3]), data[4], bool.Parse(data[5]), data[6].Split(',').ToList());
                    todos.Add(vtd);
                    break;
                case "htd":
                    HomeToDo htd = new HomeToDo(data[1], data[2], DateTime.Parse(data[3]), data[4], bool.Parse(data[5]), data[6].Split(',').ToList(), bool.Parse(data[7]));
                    todos.Add(htd);
                    break;
                default:
                    break;
            }
        }
        return todos;
    }
}