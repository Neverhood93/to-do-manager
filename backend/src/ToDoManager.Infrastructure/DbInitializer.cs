using ToDoManager.Domain.Entities;

namespace ToDoManager.Infrastructure;

public class DbInitializer
{
    public static void SeedDatabase(DatabaseContext context)
    {
        if (context.ToDoStatuses.Any())
        {
            return;
        }

        var statusNew = new ToDoStatus { Name = "Новая" };
        var statusInProgress = new ToDoStatus { Name = "В работе" };
        var statusCompleted = new ToDoStatus { Name = "Завершено" };

        context.ToDoStatuses.AddRange(statusNew, statusInProgress, statusCompleted);
        context.SaveChanges();


        var todo1 = new ToDo { Name = "Купить продукты", StatusId = statusNew.Id };
        var todo2 = new ToDo { Name = "Подготовить отчет", StatusId = statusInProgress.Id };
        var todo3 = new ToDo { Name = "Позвонить клиенту", StatusId = statusCompleted.Id };

        context.ToDos.AddRange(todo1, todo2, todo3);
        context.SaveChanges();
    }
}