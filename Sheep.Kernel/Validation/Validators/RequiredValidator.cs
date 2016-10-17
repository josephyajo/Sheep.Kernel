using Sheep.Kernel.Validation.Attributes;
using System.Reflection;

namespace Sheep.Kernel.Validation.Validators
{
    public class RequiredValidator : ValidatorHandler
    {
        public override ValidationFailure Validate(PropertyInfo property, object obj)
        {
            if (property.IsDefined(typeof(RequiredAttribute), false))
            {
                RequiredAttribute attribute = property.GetCustomAttribute(typeof(RequiredAttribute), false) as RequiredAttribute;
                attribute.PropertyName = property.Name;
                return attribute.IsValid(obj) ? null : new ValidationFailure(property.Name, attribute.ErrorMessage);
            }
            return nextValidator?.Validate(property, obj);
        }
    }
}
