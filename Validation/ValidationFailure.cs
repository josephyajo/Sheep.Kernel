namespace Sheep.Kernel.Validation
{
    public class ValidationFailure
    {
        public ValidationFailure(string memberName, string errorMessage)
        {
            MemberName = memberName;
            ErrorMessage = errorMessage;
        }

        public string MemberName { get; private set; }

        public string ErrorMessage { get; set; }
    }
}
