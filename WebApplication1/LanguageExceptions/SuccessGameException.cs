namespace WebApplication1.LanguageExceptions
{
    public class SuccessGameException:Exception,IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public SuccessGameException()
        {
            ErrorMessage = "Error var!";
        }

        public SuccessGameException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
