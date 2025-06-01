namespace ToDoList.Models
{
    public class TaskToDo
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime? DateCompleted { get; set; }
    }
}
