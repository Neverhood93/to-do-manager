using ToDoManager.Domain.Shared;

namespace ToDoManager.Domain.Entities;

public class ToDo : BaseEntity
{
    public string Name { get; set; }
    public int StatusId { get; set; }
    public virtual ToDoStatus Status { get; set; }
    public virtual IEnumerable<ToDoFile> Files { get; set; }
}
