using ToDoDemo.Models;
using ToDoDemo.Services;

namespace ToDoDemo.API.Endpoints
{
    public class CreateToDoEndpoint : Endpoint<CreateToDoDTO>
    {
        private readonly IToDoService _ToDoService;
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/create");
            AllowAnonymous();
        }

        public CreateToDoEndpoint(IToDoService ToDoService)
        {
            _ToDoService = ToDoService;
        }

        public override async Task HandleAsync(CreateToDoDTO req, CancellationToken ct)
        {
            await _ToDoService.Create(req);

            await SendOkAsync(req);
        }
    }
}
