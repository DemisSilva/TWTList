using Microsoft.AspNetCore.Mvc;
using TWTodoList.Models;
namespace TWTodoList.Controllers;
using ViewModels;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
