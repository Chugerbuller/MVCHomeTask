namespace mvc;

public interface IView
{
    void ShowMenu();

    void ShowTasks(IEnumerable<TaskItem> tasks);

    void ShowTask(TaskItem task);

    string GetTaskTitle();

    int GetTaskId();

    string GetTaskNewTitle();

    bool ConfirmExit();

    void ShowMessage(string message);
}