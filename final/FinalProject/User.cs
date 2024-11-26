public class User
{
    private string _name;
    private List<ToDo> _toDoList;
    private List<int> _surveyResult;
    public User(string name)
    {
        _name = name;
        _surveyResult = Survey.TakeSurvey();
    }
    public void CreateNewItem()
    {

    }
    public void ListItemsByDate(bool completed)
    {

    }
    public void ListItemsByType(bool completed)
    {
        
    }
    public void MarkItemCompleted()
    {

    }
    private void Save()
    {
        
    }
}