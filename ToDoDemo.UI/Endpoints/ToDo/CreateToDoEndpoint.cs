using ToDoDemo.Data;
using ToDoDemo.Models;

namespace ToDoDemo.API.Endpoints
{
    public class CreateToDoEndpoint : Endpoint<ToDoDTO>
    {
        private readonly ToDoDemoDBContext _dbContext;

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/create");
            AllowAnonymous();
        }

        public CreateToDoEndpoint(ToDoDemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
            var entry = _dbContext.Add(new ToDo());
            entry.CurrentValues.SetValues(req);
            await _dbContext.SaveChangesAsync();

            await SendOkAsync();
        }
    }
}
