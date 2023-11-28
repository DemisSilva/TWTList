using TWTodoList.Contexts;
using TWTodoList.Exceptions;
using TWTodoList.Models;
using TWTodoList.ViewModels;

namespace TWTodoList.Services;

public class TodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public ListTodoViewModel FindAll()
    {
        var todos = _context.Todos.OrderBy(x => x.Date).ToList();
        return  new ListTodoViewModel{Todos = todos};
    }

    public void Create(CreateTodoViewModel model)
    {
        var todo  = new Todo(model.Title, model.Date);
        _context.Add(todo);
        _context.SaveChanges();

    }

    public EditTodoViewModel FindById(int id)
    {
        var todo = FindByIdOdElseThrow(id);
        return new EditTodoViewModel{Title = todo.Title, Date = todo.Date};
    }

    public void UpdateById(int id, EditTodoViewModel model)
    {
        var todo = FindByIdOdElseThrow(id);

        todo.Title = model.Title;
        todo.Date = model.Date;

        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var todo = FindByIdOdElseThrow(id);

        _context.Remove(todo);
        _context.SaveChanges();
    }

    public void ToComplete(int id)
    {
        var todo = FindByIdOdElseThrow(id);

        todo.IsCompleted = true;

        _context.SaveChanges();
    }

    private Todo FindByIdOdElseThrow(int id)
    {
        var todo = _context.Todos.Find(id);

        if(todo is null)
        {
            throw new TodoNotFoundException();
        }

        return todo;
    }
}