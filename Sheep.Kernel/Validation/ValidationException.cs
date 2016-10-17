using Sheep.Kernel.Validation.Attributes;
using System;
using System.Runtime.Serialization;

namespace Sheep.Kernel.Validation
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValidationException(string errorMessage, ValidatorAttribute validatingAttribute, object value) : base(errorMessage)
        {
            this.Value = value;
            this.ValidatorAttribute = validatingAttribute;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public ValidatorAttribute ValidatorAttribute { get; private set; }

        public object Value { get; private set; }
    }
}
