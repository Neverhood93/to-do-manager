using System.Text.Json.Serialization;

namespace ToDoManager.Domain.Entities;

public class ToDoFile
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string Name { get; set; }
    public string Path { get; set; }
    public string ContentType { get; set; }
    public long Length { get; set; }
    public int ToDoId { get; set; }

    [JsonIgnore]
    public virtual ToDo ToDo { get; set; }
}