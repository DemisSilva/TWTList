using TWTodoList.Contexts;
using TWTodoList.Models;
using TWTodoList.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TWTodoList.Services;
using TWTodoList.Exceptions;


namespace TWTodoList.Controllers;

public class TodoController : Controller
{

    private readonly TodoService _service;

    public TodoController(TodoService service)
    {

        _service = service;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de tarefas";
        var viewModel = _service.FindAll();
        return View(viewModel);
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _service.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }
        catch (TodoNotFoundException)
        {
            return NotFound();
        }
    }

    public IActionResult Create()
    {
        ViewData["title"] = "Cadastrar Tarefa";
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateTodoViewModel model)
    {
        _service.Create(model);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id) 
    {
        try
        {
            var viewModel = _service.FindById(id);
            ViewData["title"] = "Editar Tarefa";
            return View(viewModel);
        }
        catch (TodoNotFoundException)
        {
            return NotFound();
        }

    }

    [HttpPost]
     public IActionResult Edit(int id, EditTodoViewModel model)
     {
        try
        {
            _service.UpdateById(id, model);
            return RedirectToAction(nameof(Index));
        }
        catch(TodoNotFoundException)
        {
            return NotFound();
        }
     }

     public IActionResult ToComplete(int id)
     {
        try
        {
            _service.ToComplete(id);
            return RedirectToAction(nameof(Index));
        }
        catch(TodoNotFoundException)
        {
            return NotFound();
        }
     }

}