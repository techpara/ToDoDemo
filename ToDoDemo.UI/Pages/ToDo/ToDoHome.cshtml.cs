using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoDemo.Data;
using ToDoDemo.Models;
namespace ToDoDemo.UI.Pages
{
    public class ToDoHomeModel : PageModel
    {
        private readonly ToDoDemoDBContext _dbContext;
        public ToDoHomeModel(ToDoDemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Models.ToDo> allTodo = new List<Models.ToDo>();

        public async Task<IActionResult> OnGetAsync()
        {
            allTodo = await _dbContext.ToDo.ToListAsync();
            return Page();
        }
    }
}
