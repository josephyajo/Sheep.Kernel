using Sheep.Kernel.Context;
using System;

namespace Sheep.Kernel.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : ValidatorAttribute
    {
        public RequiredAttribute() : base(KernelResources.RequiredAttribute_ErrorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            return !string.IsNullOrEmpty(value?.ToString());
        }
    }
}
