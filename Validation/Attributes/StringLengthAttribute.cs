using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class StringLengthAttribute : ValidatorAttribute
    {
        public StringLengthAttribute(int maximumLength, string errorMessage) : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            throw new NotImplementedException();
        }
    }
}
