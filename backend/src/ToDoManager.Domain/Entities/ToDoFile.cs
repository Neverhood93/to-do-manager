using ToDoManager.Domain.Shared;

namespace ToDoManager.Domain.Entities;

public class ToDoFile : BaseEntity
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string ContentType { get; set; }
    public int Length { get; set; }
    public int ToDoId { get; set; }
    public virtual ToDo ToDo { get; set; }
}