using Microsoft.AspNetCore.Mvc;
using TWTodoList.Models;
namespace TWTodoList.Controllers;
using ViewModels;

public class TestController : Controller
{
    public IActionResult Index()
    {
        var todo = new Todo("Finalizar o curso de Rezor", DateTime.Now);
        ViewBag.Name = "Demis";
        ViewBag.Todo = todo;
        return View();
    }

    public IActionResult ClientDetails()
    {
        var client = new Client{ Name = "Demis Souza", Email = "demis@email.com", Purchases = 110, Type = 3};

        return View(client);
    }

    public IActionResult ClientList()
    {
        var clients = new List<Client>();
        clients.Add(new Client {Name = "Demis ", Email = "demis@email.com", Purchases = 10, Type = 1});
        clients.Add(new Client {Name = "Cleyson ", Email = "cleyson@email.com", Purchases = 10, Type = 1});
        clients.Add(new Client {Name = "Sara ", Email = "sara@email.com", Purchases = 10, Type = 1});

        return View(clients);
    }

    public IActionResult TagHelpers()
    {
        var clients = new List<Client>();
        clients.Add(new Client {Name = "Demis ", Email = "demis@email.com", Purchases = 10, Type = 1});
        clients.Add(new Client {Name = "Cleyson ", Email = "cleyson@email.com", Purchases = 10, Type = 1});
        clients.Add(new Client {Name = "Sara ", Email = "sara@email.com", Purchases = 10, Type = 1});

        return View(clients);
    }

}
