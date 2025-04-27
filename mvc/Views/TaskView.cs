namespace mvc;

public class TaskView : IView
{
    public TaskView()
    {
    }

    public void ShowMenu()
    {
        Console.WriteLine("\nTo-Do List Application");
        Console.WriteLine("1. Show all tasks");
        Console.WriteLine("2. Add new task");
        Console.WriteLine("3. Complete task");
        Console.WriteLine("4. Edit task title");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
    }

    public int GetTaskId()
    {
        Console.Write("Enter task ID: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            return id;
        }

        return -1;
    }

    public string GetTaskTitle()
    {
        Console.Write("Enter task title: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public string GetTaskNewTitle()
    {
        Console.Write("Enter new task title: ");
        return Console.ReadLine() ?? string.Empty;
    }

    public void ShowTask(TaskItem task)
    {
        Console.WriteLine($"{task.Id}. [{(task.IsCompleted ? "X" : " ")}] {task.Title}");
    }

    public void ShowTasks(IEnumerable<TaskItem> tasks)
    {
        if (tasks.Count() == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("\nTasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}. [{(task.IsCompleted ? "X" : " ")}] {task.Title}");
        }
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public bool ConfirmExit()
    {
        Console.Write("Are you sure you want to exit? (Y/N): ");
        var input = Console.ReadLine()?.Trim().ToUpper();
        return input == "Y";
    }
}