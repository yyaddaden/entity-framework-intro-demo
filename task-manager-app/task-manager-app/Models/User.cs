using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace task_manager_app.Models
{
    class User
    {
        /* Definition */
        public User()
        {
            Tasks = new List<Task>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }

        /* Methods */
        public static User GetUser(int userId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            User user = taskManagerDbContext.Users.Find(userId);
            return user;
        }

        public static void AddUser(User user)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            taskManagerDbContext.Users.Add(user);
            taskManagerDbContext.SaveChanges();
        }

        public static void AddUsers(List<User> users)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            taskManagerDbContext.Users.AddRange(users);
            taskManagerDbContext.SaveChanges();
        }

        public static void ShowUser(int userId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            User user = taskManagerDbContext.Users.Find(userId);
            Console.WriteLine($"{user.UserId} - {user.Name}");
        }

        public static void ShowUsers()
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            List<User> users = taskManagerDbContext.Users.ToList();

            foreach (User user in users)
            {
                Console.WriteLine($"{user.UserId} - {user.Name}");
            }
        }

        public static void UpdateUser(int userId, string name)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            User user = taskManagerDbContext.Users.Find(userId);
            user.Name = name;
            taskManagerDbContext.SaveChanges();
        }

        public static void DeleteUser(int userId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            User user = taskManagerDbContext.Users.Find(userId);
            taskManagerDbContext.Users.Remove(user);
            taskManagerDbContext.SaveChanges();
        }

        public static void ShowTasksOfUser(int userId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            User user = taskManagerDbContext.Users.Include(u => u.Tasks)
                .ThenInclude(t => t.Priority)
                .Where(u => u.UserId == userId)
                .First();

            User.ShowUser(userId);

            string status;
            foreach (Task task in user.Tasks)
            {
                status = task.Status ? "Complete" : "Incomplete";
                Console.WriteLine($"({task.TaskId}) - [{task.Priority.Title}] - {task.Title} - ({status}) - [{task.DueDate.ToShortDateString()}]");
            }
        }
    }
}
