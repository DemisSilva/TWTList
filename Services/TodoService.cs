using TWTodoList.Exceptions;
using TWTodoList.Models;
using TWTodoList.Repositories;
using TWTodoList.ViewModels;

namespace TWTodoList.Services;

public class TodoService
{
    private readonly TodoRepository _repositoriy;


    public TodoService(TodoRepository repositoriy)
    {
        _repositoriy = repositoriy;
    }

    public ListTodoViewModel FindAll()
    {
        return  new ListTodoViewModel
        {
            Todos = _repositoriy.FindAll(x => x.Date)
        };
    }

    public void Create(CreateTodoViewModel model)
    {
        var todo  = new Todo(model.Title, model.Date);
        _repositoriy.Create(todo);
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

        _repositoriy.Update(todo);
    }

    public void DeleteById(int id)
    {
        var todo = FindByIdOdElseThrow(id);

        _repositoriy.Delete(todo);
    }

    public void ToComplete(int id)
    {
        var todo = FindByIdOdElseThrow(id);

        todo.IsCompleted = true;

        _repositoriy.Update(todo);
    }

    private Todo FindByIdOdElseThrow(int id)
    {
        var todo = _repositoriy.FindById(id);

        if(todo is null)
        {
            throw new TodoNotFoundException();
        }

        return todo;
    }
}