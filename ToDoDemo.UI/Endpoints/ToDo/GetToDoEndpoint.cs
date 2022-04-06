using ToDoDemo.Services;

namespace ToDoDemo.API.Endpoints
{
    public class GetToDoEndpoint : EndpointWithoutRequest
    {
        private readonly IToDoService _ToDoService;
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/api/todo/get");
            AllowAnonymous();
        }

        public GetToDoEndpoint(IToDoService ToDoService)
        {
            _ToDoService = ToDoService;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var allToDo = await _ToDoService.GetAll();
            await SendAsync(allToDo);
        }
    }
}
