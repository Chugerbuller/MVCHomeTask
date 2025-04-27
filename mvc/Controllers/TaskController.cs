using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Controllers;

public class TaskController
{
    private readonly IView _view;
    private readonly List<TaskItem> _tasks;
    private int _nextId = 1;

    public TaskController(IView view)
    {
        _view = view;
        _tasks = new List<TaskItem>();
    }

    public void Run()
    {
        bool exitRequested = false;

        while (!exitRequested)
        {
            _view.ShowMenu();
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowAllTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    exitRequested = _view.ConfirmExit();
                    break;
                default:
                    _view.ShowMessage("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void ShowAllTasks()
    {
        _view.ShowTasks(_tasks);
    }

    private void AddTask()
    {
        string title = _view.GetTaskTitle();

        if (string.IsNullOrWhiteSpace(title))
        {
            _view.ShowMessage("Task title cannot be empty.");
            return;
        }

        var task = new TaskItem(_nextId++, title);
        _tasks.Add(task);
        _view.ShowMessage("Task added successfully.");
    }

    private void CompleteTask()
    {
        if (_tasks.Count == 0)
        {
            _view.ShowMessage("No tasks available to complete.");
            return;
        }

        _view.ShowTasks(_tasks);
        int id = _view.GetTaskId();

        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            _view.ShowMessage($"Task {id} marked as completed.");
        }
        else
        {
            _view.ShowMessage($"Task with ID {id} not found.");
        }
    }
}

