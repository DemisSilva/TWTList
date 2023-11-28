using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TWTodoList.Contexts;
using TWTodoList.Models;

namespace TWTodoList.Repositories;

public class TodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public ICollection<Todo> FindAll()
    {
        return _context.Todos
            .AsNoTracking()
            .ToList();
    }

    public ICollection<Todo> FindAll<Tkey>(Expression<Func<Todo,Tkey>> orderBy)
    {
        return _context.Todos
            .OrderBy(orderBy)
            .AsNoTracking()
            .ToList();
    }

    public Todo Create (Todo todo)
    {
        _context.Add(todo);
        _context.SaveChanges();
        return todo;
    }

    public Todo? FindById(int id)
    {
        return _context.Todos
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefault();
    }

    public Todo Update(Todo todo)
    {
        _context.Todos.Update(todo);
        _context.SaveChanges();
        return todo;
    }

    public void Delete(Todo todo)
    {
        _context.Remove(todo);
        _context.SaveChanges();
    }
}