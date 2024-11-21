//www.plantuml.com/plantuml/png/lPB1JiCm38RlVeeS6TrUe9hGf39n0JJ10w0ijKP46bU9EuJAtfsqB4iwSUc5IwJ_T_JxS-ADP-cuQmmya3HY_RrQYLVTj0Q3piqjexFINBdLEwgFH-rvzA4oqdknStHmie4UdgIsDujI74dNSBhKqNcoFQpUh6om59wTjeSWMzAMVId26TGXH0OnfA-7-3k0ed8e6P_nSp0koKKayCbwGKMktXxHSawWHeAHjeVR2K2GDNhbTCkQR79phA0K3Q_3M9TYJsIW657oeAN8SfAPnIoWwEK-5AJYqxtshP5V-KHvkJhtY_M18WwIVrKFHLBpUIOKPuXfwwitp1TY-CjukQwei_pBMQHB_u6KjZ52xSbsVZTPAvNmWlWBEiNCnrwAr38wgUEieJPewwunFm00
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your name: ");
        var name = Console.ReadLine();
        Person person = SetupUser(name);
        bool running = true;
        while (running)
        {
            Console.WriteLine($"You have {person.Points} points.\n");

            Console.WriteLine($"Menu Options");
            Console.WriteLine($"    1. Create New Goal");
            Console.WriteLine($"    2. List Goals");
            Console.WriteLine($"    3. Save Goals");
            Console.WriteLine($"    4. Record Event");
            Console.WriteLine($"    5. Quit");
            Console.WriteLine($"Select a choice from the menu: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    person.CreateNewGoal();
                    //Console.Clear();
                    break;
                case "2":
                    person.ListGoals();
                    //Console.Clear();
                    break;
                case "3":
                    SavePerson(person);
                    //Console.Clear();
                    break;
                case "4":
                    person.RecordEvent();
                    //Console.Clear();
                    break;
                case "5":
                    Console.WriteLine("GoodBye");
                    running = false;
                    break;
                default:
                    //Console.Clear();
                    Console.WriteLine("Not a valid input, please choose an option below.\n");
                    continue;
            }
        }
    }
    public static void SavePerson(Person person)
    {
        File.WriteAllText($"{person.Name}.txt", person.SavePerson());
    }

    public static Person SetupUser(string name)
    {
        string file = $"{name}.txt";
        if(File.Exists(file))
        {
            string contents = File.ReadAllText(file);
            Person person = new Person(name);
            person.LoadPerson(contents);
            return person;
        }
        
        return new Person(name);
    }

}