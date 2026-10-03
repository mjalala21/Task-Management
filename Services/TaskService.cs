using StudentApi.Models;
namespace StudentApi.Services
{
    public class TaskService
    {
        private static List<TaskItem> taskItems = new List<TaskItem>();



        public Task<List<TaskItem>> GetTaskItemsAsync()
        {
            return Task.FromResult(taskItems);
        }

        public Task<TaskItem?> GetTaskItemAsync(int id)
        {
            var task = taskItems.FirstOrDefault(t => t.Id == id);
                return Task.FromResult(task);

        }

        public Task AddTaskAsync(TaskItem task)
        {
            task.Id = taskItems.Count + 1;
            taskItems.Add(task);
            return Task.CompletedTask;

        }

        public Task<TaskItem?> UpdateTaskAsync(int id, TaskItem task)
        {
            var existingTask = taskItems.FirstOrDefault(t => t.Id == id);
            if (existingTask == null) {
                return Task.FromResult<TaskItem?>(null);
            }

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;

            return Task.FromResult<TaskItem?>(existingTask);
        }
        public Task<bool> DeleteTaskAsync(int id)
        {
            var delete = taskItems.FirstOrDefault(t => t.Id == id);
                if(delete == null)
                {
                return Task.FromResult(false);
                }

            taskItems.Remove(delete);
            return Task.FromResult(true);
        }
    }
}
