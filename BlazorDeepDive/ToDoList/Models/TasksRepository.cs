namespace ToDoList.Models
{
    public static class TasksRepository
    {
        private static List<TaskToDo> tasks = new List<TaskToDo>()
        {
            new TaskToDo {  Id = 1 , Name = "Task 1"},
            new TaskToDo {  Id = 2 , Name = "Task 2"},
            new TaskToDo {  Id = 3 , Name = "Task 3"},
            new TaskToDo {  Id = 4 , Name = "Task 4"},
        };

        public static void AddTask(TaskToDo task)
        {
            var maxId = tasks.Max(s => s.Id);
            task.Id = maxId + 1;
            tasks.Add(task);
        }

        public static List<TaskToDo> GetTasks()
        {

            var sortedTasks = tasks
                .OrderBy(s => s.IsCompleted)
                .ThenByDescending(s => s.Id)
                .ToList();

            return sortedTasks;
        }


        public static TaskToDo? GetTaskById(int id)
        {
            var task = tasks.FirstOrDefault(s => s.Id == id);
            if (task != null)
            {
                return new TaskToDo
                {
                    Id = task.Id,
                    Name = task.Name,
                    IsCompleted = task.IsCompleted
                };
            }

            return null;
        }

        public static void UpdateTask(int taskId, TaskToDo task)
        {
            if (taskId != task.Id) return;

            var taskToUpdate = tasks.FirstOrDefault(s => s.Id == taskId);
            if (taskToUpdate != null)
            {
                taskToUpdate.IsCompleted = task.IsCompleted;
                taskToUpdate.Name = task.Name;
            }
        }

        public static void DeleteTask(int taskId)
        {
            var task = tasks.FirstOrDefault(s => s.Id == taskId);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }

        public static List<TaskToDo> SearchTasks(string tasksFilter)
        {
            return tasks.Where(s => s.Name.Contains(tasksFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private static List<TaskToDo> GetTasksCompleted(bool isCompleted)
        {
            return tasks.Where(t => t.IsCompleted == isCompleted).ToList();
        }

        public static List<TaskToDo> GetTasksOrderedByCompletedFirst(bool isCompletedFirst)
        {
            List<TaskToDo> tasks = GetTasksCompleted(isCompletedFirst);
            tasks.AddRange(GetTasksCompleted(!isCompletedFirst));

            return tasks;
        }
    }
}

