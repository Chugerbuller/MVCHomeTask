namespace mvc;

public class TaskItem
{
    public TaskItem(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; } = false;

   
}