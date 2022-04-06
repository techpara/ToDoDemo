using ToDoDemo.Models;
using ToDoDemo.Services;

namespace ToDoDemo.API.Endpoints
{
    public class DeleteToDoEndpoint : Endpoint<ToDoDTO>
    {
        private readonly IToDoService _ToDoService;

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/delete");
            AllowAnonymous();
        }

        public DeleteToDoEndpoint(IToDoService ToDoService)
        {
            _ToDoService = ToDoService;
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
            await _ToDoService.Delete(req);

            await SendOkAsync(req);
        }
    }
}
