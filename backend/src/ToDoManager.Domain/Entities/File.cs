using ToDoManager.Domain.Shared;

namespace ToDoManager.Domain.Entities;

public class File : BaseEntity
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string ContentType { get; set; }
    public int Length { get; set; }
    public Guid ToDoId { get; set; }
    public virtual ToDo ToDo { get; set; }
}