using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Tarefas.Models;

namespace Tarefas.Services
{
    public class CreateTaskService : ICreateTaskServices
    {
        public const string CONNECTION_STRING = @"Server=localhost,1433;Database=BLOG;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";
        public TaskModel CreateTask(TaskModel task)
        {
            bool isValid = false;

            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    Console.WriteLine("Banco conectado com sucesso !");
                    var query = "INSERT INTO [Tasks] VALUES(@TaskTittle, @TaskDescription, @TaskDeadline)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaskTittle", value: task.TaskTittle);
                        command.Parameters.AddWithValue("@TaskDescription", value: task.TaskDescription);
                        command.Parameters.AddWithValue("@TaskDeadline", value: task.TaskDeadline);
                        int rows = command.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            Console.WriteLine("Tarefa inserida com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Falha ao inserir a tarefa");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Algo deu errado" + ex.Message);
            }

            return task;
        }

        public List<TaskModel> GetAllTasks()
        {
            var tasks = new List<TaskModel>();
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var query = "SELECT * FROM [Tasks]";
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tasks.Add(new TaskModel
                        {
                            TaskId = reader.GetInt32(0),
                            TaskTittle = reader.GetString(1),
                            TaskDescription = reader.GetString(2),
                            TaskDeadline = reader.GetDateTime(3)
                        });
                    }
                }
            }
            return tasks;
        }
    }
}