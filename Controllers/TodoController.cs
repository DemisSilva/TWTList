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
        var todos = _context.Todos.OrderBy(x => x.Date).ToList();
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

    public IActionResult Edit(int id)
    {

        var todo  = _context.Todos.Find(id);

        if(todo is null)
        {
            return NotFound();
        }

        var viewModel = new EditTodoViewModel {Title = todo.Title, Date = todo.Date};
        ViewData["title"] = "Editar Tarefa";
        return View(viewModel);
    }
    [HttpPost]
     public IActionResult Edit(int id, EditTodoViewModel model)
     {
        var todo  = _context.Todos.Find(id);
        if(todo is null)
        {
            return NotFound();
        }
        todo.Title = model.Title;
        todo.Date = model.Date;
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
     }

     public IActionResult ToComplete(int id)
     {
        var todo  = _context.Todos.Find(id);
        if(todo is null)
        {
            return NotFound();
        }

        todo.IsCompleted = true;
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
     }

}