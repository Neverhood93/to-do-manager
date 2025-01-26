using FluentValidation;

namespace ToDoManager.Application.Features.ToDoStatuses.Commands.Create
{
    public class CreateToDoStatusValidator : AbstractValidator<CreateToDoStatusRequest>
    {
        public CreateToDoStatusValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название статуса обязательно")
                .MaximumLength(50).WithMessage("Название статуса не должно превышать 50 символов");
        }
    }
}