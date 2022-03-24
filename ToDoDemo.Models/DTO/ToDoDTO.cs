namespace ToDoDemo.Models
{
    public class ToDoDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class CreateToDoDTO
    {
        public string Name { get; set; }
    }
}
