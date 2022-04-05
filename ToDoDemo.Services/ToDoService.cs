using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDemo.Data;
using ToDoDemo.Models;

namespace ToDoDemo.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoDemoDBContext _dbContext;
        public ToDoService(ToDoDemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(CreateToDoDTO request)
        {
            var entry = _dbContext.Add(new ToDo());
            entry.CurrentValues.SetValues(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(ToDoDTO request)
        {
            var todo = await _dbContext.ToDo.FindAsync(request.ID);
            todo.Name = request.Name;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(ToDoDTO request)
        {
            var recordToDelete = await _dbContext.ToDo.FindAsync(request.ID);
            _dbContext.ToDo.Remove(recordToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ToDo>> GetAll()
        {
            return await _dbContext.ToDo.ToListAsync();
        }
    }
}
