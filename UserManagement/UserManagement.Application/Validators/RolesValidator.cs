using FluentValidation;
using UserManagement.Application.Exceptions;
using UserManagement.Application.Validators.CustomValidators;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Validators
{
    internal class RolesValidator : AbstractValidator<Role>
    {
        public RolesValidator()
        {
            RuleFor(r => r.RolName)
                .SetValidator(new NotEmptyAndNotNullValidator<Role>())
                .OverridePropertyName("Nombre del rol"); 
        }

        public void Evaluate(Role instance)
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
