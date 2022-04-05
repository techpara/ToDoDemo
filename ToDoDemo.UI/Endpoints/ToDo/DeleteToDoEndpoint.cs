using ToDoDemo.Models;
using ToDoDemo.Services;

namespace ToDoDemo.API.Endpoints
{
    public class DeleteToDoEndpoint : Endpoint<ToDoDTO>
    {
        private readonly IToDoService _toDoService;

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/delete");
            AllowAnonymous();
        }

        public DeleteToDoEndpoint(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
            await _toDoService.Delete(req);

            await SendOkAsync(req);
        }
    }
}
