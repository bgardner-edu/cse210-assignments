using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Xml.Linq;

class Program
{


    static void Main(string[] args)
    {
        string filepath; 
        List<Entry> entries = []; 

        bool start = true;
        while(start)
        {
            Console.WriteLine("Enter one of the following options");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            var input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    entries.Add(NewEntry());
                break;
                case "2":
                    foreach(Entry entry in entries)
                    {
                        entry.DisplayEntry();
                    }
                break;
                case "3":
                    Console.WriteLine("Enter Filename for entries: ");
                    filepath = Console.ReadLine();

                    var jsonEntries = JsonSerializer.Serialize(entries);
                    File.WriteAllText(filepath, jsonEntries);
                break;
                case "4":
                    Console.WriteLine("Enter Filename for entries: ");
                    filepath = Console.ReadLine();
                    var json = File.ReadAllText(filepath);
                    entries = JsonSerializer.Deserialize<List<Entry>>(json);
                break;
                case "5":
                    Console.WriteLine("GoodBye");
                    start = false;
                break;
                default:
                Console.WriteLine("Unknown input, please try again.");
                break;

            }
        }
    }
    public static Entry NewEntry()
    {
        Entry entry = new Entry();
        entry.date = DateTime.Now;
        entry.DisplayPrompt();
        entry.entry = Console.ReadLine();
        return entry;
    }
}