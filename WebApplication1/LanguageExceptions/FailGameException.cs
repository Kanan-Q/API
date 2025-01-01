namespace WebApplication1.LanguageExceptions
{
    public class FailGameException:Exception,IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public FailGameException()
        {
            ErrorMessage = "Error var!";
        }

        public FailGameException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
