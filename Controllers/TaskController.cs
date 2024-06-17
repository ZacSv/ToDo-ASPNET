using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers
{
    public class CreateTaskController : Controller
    {
        private readonly ICreateTaskServices _createTaskService;

        public CreateTaskController(ICreateTaskServices createTaskServices)
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
                    if (ModelState.IsValid)
                    {
                        _createTaskService.CreateTask(task);
                    }

                    return View("Home");
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
            return View("Home");
        }
    }
}