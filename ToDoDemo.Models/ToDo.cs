﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoDemo.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
