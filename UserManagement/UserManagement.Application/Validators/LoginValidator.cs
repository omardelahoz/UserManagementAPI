using FluentValidation;
using UserManagement.Application.Exceptions;
using UserManagement.Application.Validators.CustomValidators;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Validators
{
    internal class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Username)
                .SetValidator(new NotEmptyAndNotNullValidator<Login>())
                .OverridePropertyName("Nombre de usuario");
            RuleFor(l => l.Password)
                .SetValidator(new NotEmptyAndNotNullValidator<Login>())
                .OverridePropertyName("Contraseña");
        }

        public void Evaluate(Login instance)
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
