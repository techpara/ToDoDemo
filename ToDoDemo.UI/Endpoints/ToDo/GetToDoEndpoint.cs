using ToDoDemo.Services;

namespace ToDoDemo.API.Endpoints
{
    public class GetToDoEndpoint : EndpointWithoutRequest
    {
        private readonly IToDoService _toDoService;
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/api/todo/get");
            AllowAnonymous();
        }

        public GetToDoEndpoint(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var allToDo = await _toDoService.GetAll();
            await SendAsync(allToDo);
        }
    }
}
