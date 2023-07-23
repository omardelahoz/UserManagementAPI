using FluentValidation;
using FluentValidation.Validators;

namespace UserManagement.Application.Validators.CustomValidators
{
    internal class NotEmptyAndNotNullValidator<T> : PropertyValidator<T, string>
    {

        public override string Name => "NotEmptyAndNotNullValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        => "{PropertyName} Debe contener un valor";


        public override bool IsValid(ValidationContext<T> context, string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}
