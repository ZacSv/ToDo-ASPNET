using Tarefas.Models;

namespace Tarefas.Services
{
    public interface ICreateTaskServices
    {
        public TaskModel CreateTask(TaskModel task);
        public List<TaskModel> GetAllTasks();
    }
}