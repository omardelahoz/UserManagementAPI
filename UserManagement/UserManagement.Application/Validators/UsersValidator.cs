using FluentValidation;
using UserManagement.Application.Exceptions;
using UserManagement.Application.Validators.CustomValidators;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Validators
{
    internal class UsersValidator : AbstractValidator<User>
    {
        public UsersValidator()
        {
            RuleFor(u => u.Name)
                .SetValidator(new NotEmptyAndNotNullValidator<User>())
                .OverridePropertyName("Nombres");
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Debe ingresar un correo válido")
                .SetValidator(new NotEmptyAndNotNullValidator<User>())
                .OverridePropertyName("Email");
            RuleFor(u => u.Password)
                .SetValidator(new NotEmptyAndNotNullValidator<User>())
                .OverridePropertyName("Contraseña");
            RuleFor(u => u.Lastname).NotEmpty()
                .SetValidator(new NotEmptyAndNotNullValidator<User>())
                .OverridePropertyName("Apellidos");
        }

        public void Evaluate(User instance)
        {
            var validationresult = Validate(instance);
            if (!validationresult.IsValid)
            {
                var errors = validationresult.Errors
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

                throw new UserManagementException(errors);
            }
        }
    }
}
