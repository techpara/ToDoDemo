using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using ToDoDemo.Data;
using ToDoDemo.Models;

namespace ToDoDemo.API.Endpoints
{
    [EnableCors("ToDoCorsPolicy")]
    public class GetToDoEndpoint : Endpoint<ToDoDTO>
    {
        private readonly ToDoDemoDBContext _dbContext;
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/api/todo/get");
            AllowAnonymous();
        }

        public GetToDoEndpoint(ToDoDemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
            var allToDo = await _dbContext.ToDo.ToListAsync();
            await SendOkAsync(allToDo);
        }
    }
}
