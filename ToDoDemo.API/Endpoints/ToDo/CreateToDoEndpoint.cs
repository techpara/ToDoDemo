using ToDoDemo.Models;

namespace ToDoDemo.API.Endpoints
{
    public class CreateToDoEndpoint : Endpoint<ToDoDTO>
    {
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
           

            await SendOkAsync();
        }
    }
}
