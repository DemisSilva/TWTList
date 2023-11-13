using Microsoft.AspNetCore.Mvc;
using TWTodoList.Models;
namespace TWTodoList.Controllers;
using ViewModels;

public class TestController : Controller
{
    public IActionResult Index()
    {
        var todo = new Todo 
        {
            Title = "ASP .NET Core", 

            Description = "Concluir o curso de ASP net Core da Treina Web"
        };

        ViewBag.Todo = todo;

        TempData["message"] = "Messagem vinda da action Index";
        return View();
    }

    public IActionResult Message()
    {
        return View();
    }

    public IActionResult ViewModel()
    {
                var todo = new Todo 
        {
            Title = "ASP .NET Core", 

            Description = "Concluir o curso de ASP net Core da Treina Web"
        };
          var viewModel = new DetailsTodoViewModel
          {
            Todo = todo,
            PageTitle = "Detalhes da Tarefa"
          };

          return View(viewModel);
    }
}
