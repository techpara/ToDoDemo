using ToDoDemo.Models;
using ToDoDemo.Services;

namespace ToDoDemo.API.Endpoints
{
    public class UpdateToDoEndpoint : Endpoint<ToDoDTO>
    {
        private readonly IToDoService _ToDoService;
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/update");
            AllowAnonymous();
        }

        public UpdateToDoEndpoint(IToDoService ToDoService)
        {
            _ToDoService = ToDoService;
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
            await _ToDoService.Update(req);
            await SendOkAsync(req);
        }
    }
}
