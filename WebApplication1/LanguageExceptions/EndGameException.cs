namespace WebApplication1.LanguageExceptions
{
    public class EndGameException:Exception,IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public EndGameException()
        {
            ErrorMessage = "Error var!";
        }

        public EndGameException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
