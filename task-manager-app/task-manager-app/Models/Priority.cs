using System;
using System.Collections.Generic;
using System.Linq;

namespace task_manager_app.Models
{
    class Priority
    {
        /* Definition */
        public int PriorityId { get; set; }
        public string Title { get; set; }

        /* Methods */
        public static Priority GetPriority(int priorityId)
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            Priority priority = taskManagerDbContext.Priorities.Find(priorityId);
            return priority;
        }

        public static void ShowPriorities()
        {
            TaskManagerDbContext taskManagerDbContext = new TaskManagerDbContext();
            List<Priority> priorities = taskManagerDbContext.Priorities.ToList();

            foreach (Priority priority in priorities)
            {
                Console.WriteLine($"({priority.PriorityId}) - [{priority.Title}]");
            }
        }
    }
}
