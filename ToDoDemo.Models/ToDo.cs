using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoDemo.Models
{
    public class ToDo : BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ToDoResponse
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
