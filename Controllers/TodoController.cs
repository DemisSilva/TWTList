using TWTodoList.Contexts;
using TWTodoList.Models;
using TWTodoList.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace TWTodoList.Controllers;

public class TodoController : Controller
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var todos = _context.Todos.ToList();
        var viewModel = new ListTodoViewModel{Todos = todos};
        ViewData["Title"] = "Lista de tarefas";
        return View(viewModel);
    }

    public IActionResult Delete(int id)
    {
        var todo = _context.Todos.Find(id);
        if(todo is null)
        {
            return NotFound();
        }

        _context.Remove(todo);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create()
    {
        ViewData["title"] = "Cadastrar Tarefa";
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateTodoViewModel model)
    {
        var todo = new Todo(model.Title, model.Date);
        _context.Add(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

}