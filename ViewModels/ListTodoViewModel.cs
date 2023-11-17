using TWTodoList.Models;
using Microsoft.AspNetCore.Mvc;


namespace TWTodoList.ViewModels;

public class ListTodoViewModel
{
    public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    
}