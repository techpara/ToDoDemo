using ToDoDemo.Models;
using ToDoDemo.Services;

namespace ToDoDemo.API.Endpoints
{
    public class UpdateToDoEndpoint : Endpoint<ToDoDTO>
    {
        private readonly IToDoService _toDoService;
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/update");
            AllowAnonymous();
        }

        public UpdateToDoEndpoint(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
            await _toDoService.Update(req);
            await SendOkAsync(req);
        }
    }
}
