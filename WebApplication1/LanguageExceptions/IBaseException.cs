namespace WebApplication1.LanguageExceptions
{
    public interface IBaseException
    {
        int StatusCode { get; }
        string ErrorMessage { get; }
    }
}
