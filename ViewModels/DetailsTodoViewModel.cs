namespace TWTodoList.ViewModels;
using Models;


public class DetailsTodoViewModel
{
    public Todo Todo { get; set; } = null!;

    public string PageTitle { get; set; } = string.Empty;
}