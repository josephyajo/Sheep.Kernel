using Sheep.Kernel.Validation.Attributes;
using System.Reflection;

namespace Sheep.Kernel.Validation.Validators
{
    public class RegularExpressionValidator : ValidatorHandler
    {
        public override ValidationFailure Validate(PropertyInfo property, object obj)
        {
            if (property.IsDefined(typeof(RegularExpressionAttribute), false))
            {
                RegularExpressionAttribute attribute = property.GetCustomAttribute(typeof(RegularExpressionAttribute), false) as RegularExpressionAttribute;
                attribute.PropertyName = property.Name;
                return attribute.IsValid(obj) ? new ValidationFailure(property.Name, attribute.ErrorMessage) : null;
            }
            return nextValidator?.Validate(property, obj);
        }
    }
}
