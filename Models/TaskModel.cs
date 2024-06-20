namespace Tarefas.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string TaskTittle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDeadline { get; set; }
    }
}