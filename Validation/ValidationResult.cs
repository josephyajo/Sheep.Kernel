using System.Collections.Generic;

namespace Sheep.Kernel.Validation
{
    public class ValidationResult
    {
        private IList<ValidationFailure> errors;

        public ValidationResult(IList<ValidationFailure> failures)
        {
            errors = failures;
        }

        public bool IsValid
        {
            get
            {
                return errors.Count == 0;
            }
        }

        public IList<ValidationFailure> Errors
        {
            get
            {
                return errors;
            }
        }
    }
}
