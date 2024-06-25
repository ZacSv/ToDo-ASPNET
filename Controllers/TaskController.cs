using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers
{
    public class TaskController : Controller
    {
        private readonly ICreateTaskServices _createTaskService;


        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _createTaskService.GetAllTasks();
            return View(tasks);
        }

        public TaskController(ICreateTaskServices createTaskServices)
        {
            _createTaskService = createTaskServices;
        }
        [HttpPost]
        public ActionResult CreateTask(TaskModel task)
        {
            if (task != null)
            {
                TaskModel newTask = new TaskModel();
                newTask.TaskTittle = task.TaskTittle;
                newTask.TaskDescription = task.TaskDescription;
                newTask.TaskDeadline = task.TaskDeadline;

                try
                {
                    _createTaskService.CreateTask(task);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Houve algum erro" + ex.Message);
                    return View("Home");
                }
            }
            else
            {
                Console.WriteLine("Algo deu errado, job abortado");
            }
            return View("CreateTask");
        }
    }
}