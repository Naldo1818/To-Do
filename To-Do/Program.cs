using System;
using System.Collections.Generic;
using System.IO;

class TaskManager
{
    private static List<string> tasks = new List<string>();
    private const string filePath = "tasks.txt";

    static void Main()
    {
        LoadTasks();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Task Manager");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ViewTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    RemoveTask();
                    break;
                case "4":
                    SaveTasks();
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            tasks = new List<string>(File.ReadAllLines(filePath));
        }
    }

    private static void SaveTasks()
    {
        File.WriteAllLines(filePath, tasks);
    }

    private static void ViewTasks()
    {
        Console.Clear();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    private static void AddTask()
    {
        Console.Clear();
        Console.Write("Enter new task: ");
        string task = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(task))
        {
            tasks.Add(task);
            Console.WriteLine("Task added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid input. Task not added.");
        }
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    private static void RemoveTask()
    {
        ViewTasks();
        Console.Write("Enter task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Task removed successfully!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }
}
