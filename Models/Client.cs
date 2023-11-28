namespace TWTodoList.Models;

public class Client
{
    public string Name { get; set; }  = string.Empty;
    public string Email { get; set; } = string.Empty;
    public uint Purchases { get; set; }
    public uint Type { get; set; }
}