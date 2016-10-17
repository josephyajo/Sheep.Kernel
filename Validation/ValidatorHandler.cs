using System;
using System.Reflection;

namespace Sheep.Kernel.Validation
{
    public abstract class ValidatorHandler
    {
        protected ValidatorHandler nextValidator;

        public void SetNextValidator(ValidatorHandler nextValidator)
        {
            this.nextValidator = nextValidator;
        }

        public abstract ValidationFailure Validate(PropertyInfo property, object obj);
    }
}
