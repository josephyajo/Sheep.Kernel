using Sheep.Kernel.Reflaction;
using Sheep.Kernel.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sheep.Kernel.Validation
{
    public class ValidationManager
    {
        public static ValidationResult Validate<T>(T validateObject)
        {
            if (validateObject == null)
                throw new ArgumentNullException("validateObject");

            ValidatorHandler required = new RequiredValidator();
            ValidatorHandler regularExpression = new RegularExpressionValidator();
            ValidatorHandler stringLength = new StringLengthValidator();
            required.SetNextValidator(regularExpression);
            regularExpression.SetNextValidator(stringLength);

            IList<ValidationFailure> failures = new List<ValidationFailure>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Func<object, object> getValue = ReappearMember.CreatePropertyGetter(property);
                ValidationFailure failure = required.Validate(property, getValue(validateObject));
                if (failure != null) failures.Add(failure);
            }
            return new ValidationResult(failures);
        }
    }
}
