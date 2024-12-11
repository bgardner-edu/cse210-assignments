//www.plantuml.com/plantuml/png/lPB1JiCm38RlVeeS6TrUe9hGf39n0JJ10w0ijKP46bU9EuJAtfsqB4iwSUc5IwJ_T_JxS-ADP-cuQmmya3HY_RrQYLVTj0Q3piqjexFINBdLEwgFH-rvzA4oqdknStHmie4UdgIsDujI74dNSBhKqNcoFQpUh6om59wTjeSWMzAMVId26TGXH0OnfA-7-3k0ed8e6P_nSp0koKKayCbwGKMktXxHSawWHeAHjeVR2K2GDNhbTCkQR79phA0K3Q_3M9TYJsIW657oeAN8SfAPnIoWwEK-5AJYqxtshP5V-KHvkJhtY_M18WwIVrKFHLBpUIOKPuXfwwitp1TY-CjukQwei_pBMQHB_u6KjZ52xSbsVZTPAvNmWlWBEiNCnrwAr38wgUEieJPewwunFm00

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your username: ");
        var name = Console.ReadLine();
        User user = Data.SetupUser(name);
        bool running = true;
        while (running)
        {
            Console.WriteLine($"Welcome {name}!");

            //Display menu
            Console.WriteLine($"Menu");
            Console.WriteLine($"    1. Add New To Do Item");
            Console.WriteLine($"    2. List To Do's by Category");
            Console.WriteLine($"    3. List To Do's by Priority");
            Console.WriteLine($"    4. Mark To Do Completed");
            Console.WriteLine($"    5. Quit");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    user.CreateNewItem();
                    break;
                case "2":
                    user.ListItemsByType();
                    break;
                case "3":
                    user.ListItemsByDate();
                    break;
                case "4":
                    user.MarkItemCompleted();
                    break;
                case "5":
                    Console.WriteLine("GoodBye");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Not a valid input, please choose an option below.\n");
                    continue;
            }
        }
    }
}