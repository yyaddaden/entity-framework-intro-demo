using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace task_manager_app.Models
{
    class Task
    {
        /* Definition */
        public int TaskId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        /* Methods */
        public static Task GetTask(int taskId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            Task task = taskManagerDbContext.Tasks.Find(taskId);
            return task;
        }

        public static void AddTask(Task task)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            taskManagerDbContext.Tasks.Add(task);
            taskManagerDbContext.SaveChanges();
        }

        public static void AddTasks(List<Task> tasks)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            taskManagerDbContext.Tasks.AddRange(tasks);
            taskManagerDbContext.SaveChanges();
        }

        public static void ShowTask(int taskId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            Task task = taskManagerDbContext.Tasks.Include(t => t.User).Include(t => t.Priority).Where(t => t.TaskId == taskId).First();
            string status = task.Status ? "Complete" : "Incomplete";
            Console.WriteLine($"({task.TaskId}) - [{task.Priority.Title}] - {task.Title} - ({status}) - {task.User.Name} - [{task.DueDate.ToShortDateString()}]");
        }

        public static void ShowTasks()
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            List<Task> tasks = taskManagerDbContext.Tasks.Include(t => t.User).Include(t => t.Priority).ToList();
            string status;

            foreach (Task task in tasks)
            {
                status = task.Status ? "Complete" : "Incomplete";
                Console.WriteLine($"({task.TaskId}) - [{task.Priority.Title}] - {task.Title} - ({status}) - {task.User.Name} - [{task.DueDate.ToShortDateString()}]");
            }
        }

        public static void ChangeStatusTask(int taskId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            Task task = taskManagerDbContext.Tasks.Find(taskId);
            task.Status = !task.Status;
            taskManagerDbContext.SaveChanges();
        }

        public static void DeleteTask(int taskId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            Task task = taskManagerDbContext.Tasks.Find(taskId);
            taskManagerDbContext.Tasks.Remove(task);
            taskManagerDbContext.SaveChanges();
        }
    }
}
