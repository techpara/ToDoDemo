using ToDoDemo.Data;
using ToDoDemo.Models;
using ToDoDemo.Services;

namespace ToDoDemo.API.Endpoints
{
    public class CreateToDoEndpoint : Endpoint<CreateToDoDTO>
    {
        private readonly IToDoService _toDoService;

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/create");
            AllowAnonymous();
        }

        public CreateToDoEndpoint(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public override async Task HandleAsync(CreateToDoDTO req, CancellationToken ct)
        {
            await _toDoService.Create(req);

            await SendOkAsync(req);
        }
    }
}
