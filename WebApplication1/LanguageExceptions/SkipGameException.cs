namespace WebApplication1.LanguageExceptions
{
    public class SkipGameException:Exception,IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public SkipGameException()
        {
            ErrorMessage = "Error var!";
        }

        public SkipGameException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
