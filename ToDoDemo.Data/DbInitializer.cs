using ToDoDemo.Models;

namespace ToDoDemo.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ToDoDemoDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.ToDo.Any())
            {
                return;
            }

            var categories = new ToDo[]
            {
                new ToDo{ Name = "Attand client meeting"},
                new ToDo{ Name = "Team discussion"}
            };

            context.ToDo.AddRange(categories);
            context.SaveChanges();
        }
    }
}

