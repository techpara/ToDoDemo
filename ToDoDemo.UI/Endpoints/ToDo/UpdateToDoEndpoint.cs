using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoDemo.Data;
using ToDoDemo.Models;

namespace ToDoDemo.API.Endpoints
{
    public class UpdateToDoEndpoint : Endpoint<ToDoDTO>
    {
        private readonly ToDoDemoDBContext _dbContext;
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/update");
            AllowAnonymous();
        }

        public UpdateToDoEndpoint(ToDoDemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
            var todo = await _dbContext.ToDo.FindAsync(req.ID);

            if (todo == null)
            {
                await SendNotFoundAsync();
            }

            //TO-DO Can use automapper
            todo.Name = req.Name;
            await _dbContext.SaveChangesAsync();
        
            await SendOkAsync();
        }
    }
}
