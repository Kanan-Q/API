namespace WebApplication1.LanguageExceptions
{
    public class StartGameException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage {  get; }

        public StartGameException()
        {
            ErrorMessage = "Error var!";
        }

        public StartGameException(string message):base(message) 
        {
            ErrorMessage=message;
        }
    }
}
