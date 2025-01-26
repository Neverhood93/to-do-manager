using FluentValidation;

namespace ToDoManager.Application.Features.ToDos.Commands.Create;

public class CreateToDoValidator : AbstractValidator<CreateToDoRequest>
{
    public CreateToDoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название не должно быть пустым")
            .MaximumLength(200).WithMessage("Название не должно превышать 200 символов");

        RuleFor(x => x.StatusId)
            .NotEmpty().WithMessage("Статус обязателен");
    }
}
