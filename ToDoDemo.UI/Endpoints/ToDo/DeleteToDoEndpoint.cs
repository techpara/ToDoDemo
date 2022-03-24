using ToDoDemo.Data;
using ToDoDemo.Models;

namespace ToDoDemo.API.Endpoints
{
    public class DeleteToDoEndpoint : Endpoint<ToDoDTO>
    {
        private readonly ToDoDemoDBContext _dbContext;

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/delete");
            AllowAnonymous();
        }

        public DeleteToDoEndpoint(ToDoDemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
            var recordToDelete = await _dbContext.ToDo.FindAsync(req.ID);

            if (recordToDelete == null)
            {
                await SendNotFoundAsync();
            }

            _dbContext.ToDo.Remove(recordToDelete);
            await _dbContext.SaveChangesAsync();

            await SendOkAsync();
        }
    }
}
