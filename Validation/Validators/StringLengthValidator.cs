using Sheep.Kernel.Validation.Attributes;
using System.Reflection;

namespace Sheep.Kernel.Validation.Validators
{
    public class StringLengthValidator : ValidatorHandler
    {
        public override ValidationFailure Validate(PropertyInfo property, object obj)
        {
            if (property.IsDefined(typeof(StringLengthAttribute), false))
            {
                StringLengthAttribute attribute = property.GetCustomAttribute(typeof(StringLengthAttribute), false) as StringLengthAttribute;
                attribute.PropertyName = property.Name;
                return attribute.IsValid(obj) ? new ValidationFailure(property.Name, attribute.ErrorMessage) : null;
            }
            return nextValidator?.Validate(property, obj);
        }
    }
}
