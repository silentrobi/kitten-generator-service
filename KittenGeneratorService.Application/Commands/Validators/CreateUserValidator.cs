using FluentValidation;
using System.Collections.Generic;

namespace KittenGeneratorService.Application.Commands.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            List<string> roles = new() { "admin", "user" };

            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(model => model.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Required password field");

            RuleFor(model => model.Username)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Required username field");

            RuleFor(model => model.Role)
                .NotNull().WithMessage("Required role field")
                .Must(x => roles.Contains(x)).WithMessage("Invalid role");
        }
    }
}
