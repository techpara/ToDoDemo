using ToDoDemo.Models;

namespace ToDoDemo.Services
{
    public interface IToDoService
    {
        Task Create(CreateToDoDTO request);
        Task Update(ToDoDTO request);
        Task Delete(ToDoDTO request);
        Task<List<ToDo>> GetAll();
    }
}