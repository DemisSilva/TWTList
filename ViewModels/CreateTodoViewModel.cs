using TWTodoList.Models;
using Microsoft.AspNetCore.Mvc;

namespace TWTodoList.ViewModels;

public class CreateTodoViewModel
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

