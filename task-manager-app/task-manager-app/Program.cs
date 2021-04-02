using System.Collections.Generic;

namespace task_manager_app
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Add users */
            Models.User.AddUsers(new List<Models.User>()
            {
                new Models.User(){ Name = "Albert" },
                new Models.User(){ Name = "Amélie" }
            });

            /* Show users */
            Models.User.ShowUsers();

            /* Show a user */
            Models.User.ShowUser(1);

            /* Add tasks */
            Models.Task.AddTasks(new List<Models.Task>()
            {
                new Models.Task()
                {
                    Title = "Faire le devoir de POO",
                    Status = true,
                    DueDate = new System.DateTime(2021, 7, 2),
                    UserId = 1,
                    PriorityId = 1
                },
                new Models.Task()
                {
                    Title = "Passer l'examen de TCE",
                    Status = false,
                    DueDate = new System.DateTime(2021, 6, 8),
                    UserId = 2,
                    PriorityId = 3
                },
                new Models.Task()
                {
                    Title = "Faire le travail pratique",
                    Status = true,
                    DueDate = new System.DateTime(2021, 4, 15),
                    UserId = 1,
                    PriorityId = 2
                },
                new Models.Task()
                {
                    Title = "Aller se balader",
                    Status = false,
                    DueDate = new System.DateTime(2021, 5, 5),
                    UserId = 2,
                    PriorityId = 2
                }
            });

            /* Show a task */
            Models.Task.ShowTask(1);

            /* Show tasks */
            Models.Task.ShowTasks();

            /* Show tasks per users */
            Models.User.ShowTasksOfUser(1);
        }
    }
}
