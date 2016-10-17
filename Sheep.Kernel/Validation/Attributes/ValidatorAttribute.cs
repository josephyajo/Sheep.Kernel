using Sheep.Kernel.Context;
using System;
using System.Globalization;

namespace Sheep.Kernel.Validation.Attributes
{
    public abstract class ValidatorAttribute : Attribute
    {
        protected ValidatorAttribute()
        {
        }

        protected ValidatorAttribute(string errorMessage)
        {
            this.ErrorMessage = string.Format(CultureInfo.CurrentCulture, errorMessage, new object[] { PropertyName });
        }

        public abstract bool IsValid(object value);

        public string ErrorMessage { get; private set; }

        public string PropertyName { private get; set; }
    }
}
