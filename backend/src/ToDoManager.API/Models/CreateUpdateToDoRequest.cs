namespace ToDoManager.API.Models;

public class CreateUpdateToDoRequest
{
    public string Name { get; set; }
    public Guid StatusId { get; set; }
}
