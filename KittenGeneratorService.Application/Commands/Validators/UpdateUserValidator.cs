using FluentValidation;

namespace KittenGeneratorService.Application.Commands.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(model => model.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Required password field");

            RuleFor(model => model.Username)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Required username field");
            RuleFor(model => model.Role)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Required role field");
        }
    }
}
