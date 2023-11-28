namespace TWTodoList.Exceptions;

public class TodoNotFoundException : System.Exception
{
    public TodoNotFoundException(string message ="Todo not found") : base(message)
    {
        
    }
}