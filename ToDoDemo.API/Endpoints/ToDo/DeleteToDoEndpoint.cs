using ToDoDemo.Models;

namespace ToDoDemo.API.Endpoints
{
    public class DeleteToDoEndpoint : Endpoint<ToDoDTO>
    {
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/todo/delete");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ToDoDTO req, CancellationToken ct)
        {
           

            await SendOkAsync();
        }
    }
}
