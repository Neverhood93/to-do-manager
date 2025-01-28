namespace ToDoManager.API.Models;

public class CreateUpdateToDoRequest
{
    public string Name { get; set; }
    public int StatusId { get; set; }
}
