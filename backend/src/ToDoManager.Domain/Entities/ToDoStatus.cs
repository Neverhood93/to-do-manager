using ToDoManager.Domain.Shared;

namespace ToDoManager.Domain.Entities;

public class ToDoStatus : BaseEntity
{
    public string Name { get; set; }
    public virtual IEnumerable<ToDo> ToDos { get; set; }
}
