using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using ToDoDemo.Data;
using ToDoDemo.Models;

namespace ToDoDemo.API.Endpoints
{
   

    public class GetToDoEndpoint : EndpointWithoutRequest
    {
        private readonly ToDoDemoDBContext _dbContext;
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/api/todo/get");
            AllowAnonymous();
            //SerializerContext<UpdateAddressCtx>();
        }

        public GetToDoEndpoint(ToDoDemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var allToDo = await _dbContext.ToDo.ToListAsync(); 
            await SendAsync(allToDo);
        }
    }
}
